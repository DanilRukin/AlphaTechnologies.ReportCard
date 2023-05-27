using AlphaTechnologies.ReportCard.Data;
using AlphaTechnologies.ReportCard.Presentation.WPF.Models.Services;
using AlphaTechnologies.ReportCard.Presentation.WPF.ViewModels;
using AlphaTechnologies.ReportCard.SharedKernel;
using AlphaTechnologies.ReportCard.SharedKernel.Interfaces;
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

namespace AlphaTechnologies.ReportCard.Presentation.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Window FocusedWindow => Current.Windows.Cast<Window>().FirstOrDefault(w => w.IsFocused);

        public static Window ActivedWindow => Current.Windows.Cast<Window>().FirstOrDefault(w => w.IsActive);

        private static IHost _host;

        public static IHost Host => _host ??= Program.CreateHostBuilder(Environment.GetCommandLineArgs()).Build();

        private static string _migrationAssembly = "AlphaTechnologies.ReportCard.Data.MySql";

        public static IServiceProvider Services => Host.Services;

        public static void ConfigureServices(HostBuilderContext host, IServiceCollection services) => services
           .AddServices()
           .AddViewModels()
           .AddMediatR(conf =>
           {
               conf.RegisterServicesFromAssembly(typeof(Program).Assembly);
           })
           .AddScoped<IDomainEventDispatcher, DomainEventDispatcher>()
           .AddDbContext<AlphaTechnologiesRepordCardDbContext>(options =>
           {
               options.UseMySQL("Server=myServerAddress;Database=myDataBase;Uid=myUsername;Pwd=myPassword;",
                   sql => sql.MigrationsAssembly(_migrationAssembly));
           });

        protected override async void OnStartup(StartupEventArgs e)
        {
            var host = Host;

            base.OnStartup(e);

            await host.StartAsync();

        }

        protected override async void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);

            using (Host) await Host.StopAsync();
        }
    }
}
