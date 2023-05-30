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
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace AlphaTechnologies.ReportCard.Presentation.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : System.Windows.Application
    {
        public static Window FocusedWindow => Current.Windows.Cast<Window>().FirstOrDefault(w => w.IsFocused);

        public static Window ActivedWindow => Current.Windows.Cast<Window>().FirstOrDefault(w => w.IsActive);

        private IHost _host;
        private DatabaseProfile _profile;

        public App()
        {
            _host = Host.CreateDefaultBuilder(Environment.GetCommandLineArgs())
                .ConfigureLogging((context, logging) =>
                {
                    Log.Logger = new LoggerConfiguration()
                    .ReadFrom
                    .Configuration(context.Configuration)
                    .CreateLogger();
                    //logging.AddSerilog();
                })
                .ConfigureServices(ConfigureServices)
                .UseSerilog()
                .Build();

            //using (var scope = _host.Services.CreateScope())
            //{
            //    var services = scope.ServiceProvider;
            //    var context = services.GetRequiredService<AlphaTechnologiesRepordCardDbContext>();
            //    _profile?.UseDbContext(context);
            //}
        }

        private void ConfigureServices(HostBuilderContext context, IServiceCollection services)
        {
            DatabaseProfileFactory factory = new DatabaseProfileFactory();
            _profile = factory.CreateFromConfiguration(context.Configuration);
            services.AddApplicationModule()
                .AddScoped<IDomainEventDispatcher, DomainEventDispatcher>()
                .AddDbContext<AlphaTechnologiesRepordCardDbContext>(_profile.ConfigureDbContextOptionsBuilder);

            services.AddSingleton(LoggerFactory.Create(logging => logging.AddSerilog()).CreateLogger("Logger"));

            services.AddTransient<MainWindowViewModel>();
            services.AddTransient<ReportCardWindowViewModel>();
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
            base.OnStartup(e);
            await _host.StartAsync();

            //var context = _host.Services.GetRequiredService<AlphaTechnologiesRepordCardDbContext>();
            //_profile?.UseDbContext(context);

            using (var scope = _host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<AlphaTechnologiesRepordCardDbContext>();
                _profile?.UseDbContext(context);
            }

            var window = _host.Services.GetRequiredService<ReportCardWindow>();
            window.Show();
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);

            using (_host) await _host.StopAsync();
        }


    }
}
