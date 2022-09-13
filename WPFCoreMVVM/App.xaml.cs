using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyEventsEntityFrameworkDb.DbContexts;
using MyEventsEntityFrameworkDb.EFRepositories.Contracts;
using MyEventsEntityFrameworkDb.EFRepositories;
using System;
using System.Data;
using System.Linq;
using System.Windows;
using WPFCoreMVVM.Services;
using WPFCoreMVVM.ViewModels;
using MyEventsAdoNetDB.Repositories;
using MyEventsAdoNetDB.Repositories.Interfaces;

namespace WPFCoreMVVM
{
    public partial class App
    {
        public static Window ActivedWindow => Current.Windows.Cast<Window>().FirstOrDefault(w => w.IsActive);

        public static Window FocusedWindow => Current.Windows.Cast<Window>().FirstOrDefault(w => w.IsFocused);

        private static IHost __Host;

        public static IHost Host => __Host ??= Microsoft.Extensions.Hosting.Host
           .CreateDefaultBuilder(Environment.GetCommandLineArgs())
           
            //////////////////////////////
            // НАЛАШТУВАННЯ КОНФІГУРУВАННЯ
           .ConfigureAppConfiguration((hostBuilderContext, configurationBuilder) =>
           {
                hostBuilderContext.HostingEnvironment.EnvironmentName = System.Environment.GetEnvironmentVariable("NETCORE_ENVIRONMENT");
                var env = hostBuilderContext.HostingEnvironment;
                configurationBuilder.AddEnvironmentVariables();
                configurationBuilder.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                configurationBuilder.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: false, reloadOnChange: true);
           })

           ////////////////////////
           // НАЛАШТУВАННЯ СЕРВІСІВ
           .ConfigureServices((hostBuilderContext, serviceCollection) =>
           {
               // Connection/Transaction for ADO.NET/DAPPER database
               serviceCollection.AddScoped((s) => new SqlConnection(hostBuilderContext.Configuration.GetConnectionString("MSSQLConnection")));
               serviceCollection.AddScoped<IDbTransaction>(s =>
               {
                   SqlConnection conn = s.GetRequiredService<SqlConnection>();
                   conn.Open();
                   return conn.BeginTransaction();
               });
               // Connection for EF database + DbContext
               serviceCollection.AddDbContext<MyEventsDbContext>(options =>
               {
                   string connectionString = hostBuilderContext.Configuration.GetConnectionString("MSSQLConnection");
                   options.UseSqlServer(connectionString);
               });
               // Dependendency Injection for Repositories/UOW from ADO.NET DAL
               serviceCollection.AddScoped<IEventRepository, EventRepository>();
               serviceCollection.AddScoped<ICategoryRepository, CategoryRepository>();
               serviceCollection.AddScoped<IUserProfileRepository, UserProfileRepository>();
               serviceCollection.AddScoped<IGalleryRepository, GalleryRepository>();
               serviceCollection.AddScoped<IMessageRepository, MessageRepository>();
               serviceCollection.AddScoped<IImageRepository, ImageRepository>();
               serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
               // Dependendency Injection for Repositories/UOW from EF DAL
               serviceCollection.AddScoped<IEFEventRepository, EFEventRepository>();
               serviceCollection.AddScoped<IEFCategoryRepository, EFCategoryRepository>();
               serviceCollection.AddScoped<IEFUserProfileRepository, EFUserProfileRepository>();
               serviceCollection.AddScoped<IEFGalleryRepository, EFGalleryRepository>();
               serviceCollection.AddScoped<IEFMessageRepository, EFMessageRepository>();
               serviceCollection.AddScoped<IEFImageRepository, EFImageRepository>();
               serviceCollection.AddScoped<IEFUnitOfWork, EFUnitOfWork>();

               serviceCollection.AddServices();
               serviceCollection.AddViewModels();
           })          
            
           //////////////////////////
           // НАЛАШТУВАННЯ ЛОГІЮВАННЯ 
           .ConfigureLogging((hostBuilderContext, loggingBuilder) =>
           {
           })
           .Build();

        public static IServiceProvider Services => Host.Services;

        protected override async void OnStartup(StartupEventArgs e)
        {
            var host = Host;
            base.OnStartup(e);
            await host.StartAsync();
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
            using var host = Host;
            await host.StopAsync();
        }
    }
}
