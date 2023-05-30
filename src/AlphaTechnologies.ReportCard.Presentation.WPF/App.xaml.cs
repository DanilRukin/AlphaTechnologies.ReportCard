using AlphaTechnologies.ReportCard.Application;
using AlphaTechnologies.ReportCard.Data;
using AlphaTechnologies.ReportCard.Presentation.WPF.Infrastructure.Configuration.DatabaseProfiles;
using AlphaTechnologies.ReportCard.Presentation.WPF.Infrastructure.Configuration.DatabaseProfiles.Base;
using AlphaTechnologies.ReportCard.Presentation.WPF.ViewModels;
using AlphaTechnologies.ReportCard.Presentation.WPF.Views.Windows;
using AlphaTechnologies.ReportCard.SharedKernel;
using AlphaTechnologies.ReportCard.SharedKernel.Interfaces;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using static System.Formats.Asn1.AsnWriter;

namespace AlphaTechnologies.ReportCard.Presentation.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : System.Windows.Application
    {
        public static Window FocusedWindow => Current.Windows.Cast<Window>().FirstOrDefault(w => w.IsFocused);

        public static Window ActivedWindow => Current.Windows.Cast<Window>().FirstOrDefault(w => w.IsActive);

        private static IServiceProvider? _services;
        public static IServiceProvider? Services => _services ??= Host.Services;

        private static IHost _host;
        public static IHost Host => _host ??= Microsoft.Extensions.Hosting.Host
            .CreateDefaultBuilder(Environment.GetCommandLineArgs())
            .ConfigureServices(ConfigureServices)
            .Build();

        private static DatabaseProfile _profile;

        private static void ConfigureServices(HostBuilderContext context, IServiceCollection services)
        {
            DatabaseProfileFactory factory = new DatabaseProfileFactory();
            _profile = factory.CreateFromConfiguration(context.Configuration);
            services.AddMediatR(conf =>
            {
                conf.RegisterServicesFromAssembly(typeof(App).Assembly);
            })
           .AddApplicationModule()
           .AddScoped<IDomainEventDispatcher, DomainEventDispatcher>()
           .AddDbContext<AlphaTechnologiesRepordCardDbContext>(_profile.ConfigureDbContextOptionsBuilder);

            services.AddTransient<MainWindowViewModel>();
            services.AddTransient<ReportCardWindowViewModel>();

            using (var scope = services.BuildServiceProvider().CreateScope())
            {
                var s = scope.ServiceProvider;
                var c = s.GetRequiredService<AlphaTechnologiesRepordCardDbContext>();
                _profile?.UseDbContext(c);
            }

            services.AddTransient(
            s =>
            {
                var scope = s.CreateScope();
                var model = scope.ServiceProvider.GetRequiredService<ReportCardWindowViewModel>();
                var window = new ReportCardWindow { DataContext = model };
                model.DialogComplete += (_, _) => window.Close();
                window.Closed += (_, _) => scope.Dispose();
                window.Loaded += (_, _) => model.LoadDepartments();

                return window;
            });


        }           

        protected override async void OnStartup(StartupEventArgs e)
        {
            var host = Host;
            base.OnStartup(e);
            await host.StartAsync();

            //var context = Services.GetRequiredService<AlphaTechnologiesRepordCardDbContext>();
            //_profile?.UseDbContext(context);

            //using (var scope = Services.CreateScope())
            //{
            //    var services = scope.ServiceProvider;
            //    var context = services.GetRequiredService<AlphaTechnologiesRepordCardDbContext>();
            //    _profile?.UseDbContext(context);
            //}

            var window = Services.GetRequiredService<ReportCardWindow>();
            window.Show();
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);

            using (Host) await Host.StopAsync();
        }


    }
}
