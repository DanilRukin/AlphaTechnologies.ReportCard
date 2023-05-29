using AlphaTechnologies.ReportCard.Data;
using AlphaTechnologies.ReportCard.Presentation.WPF.ViewModels;
using AlphaTechnologies.ReportCard.Presentation.WPF.Views.Windows;
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

        private static string _migrationAssembly = "AlphaTechnologies.ReportCard.Data.MySql";

        private static IServiceProvider? _services;
        public static IServiceProvider? Services => _services ??= InitializeServices().BuildServiceProvider();

        private static IServiceCollection InitializeServices()
        {
            var services = new ServiceCollection();

            services.AddMediatR(conf =>
            {
                conf.RegisterServicesFromAssembly(typeof(App).Assembly);
            })
           .AddScoped<IDomainEventDispatcher, DomainEventDispatcher>()
           .AddDbContext<AlphaTechnologiesRepordCardDbContext>(options =>
           {
               options.UseMySQL("Server=myServerAddress;Database=myDataBase;Uid=myUsername;Pwd=myPassword;",
                   sql => sql.MigrationsAssembly(_migrationAssembly));
           });

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

                return window;
            });

            return services;
        }           

        protected override void OnStartup(StartupEventArgs e)
        {
            var window = Services.GetRequiredService<ReportCardWindow>();
            window.Show();
        }
    }
}
