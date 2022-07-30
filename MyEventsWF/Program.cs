using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyEventsAdoNetDB.Repositories;
using MyEventsAdoNetDB.Repositories.Interfaces;
using MyEventsEntityFrameworkDb.DbContexts;
using MyEventsEntityFrameworkDb.EFRepositories;
using MyEventsEntityFrameworkDb.EFRepositories.Contracts;
using MyEventsWF.Forms;
using MyEventsWF.Helpers;
using System.Data;
using System.Data.SqlClient;

namespace MyEventsWF
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //ÑÒÂÎÐÅÍÍß GENERIC HOST
            var host = Host.CreateDefaultBuilder()
                     .ConfigureAppConfiguration((hostBuilderContext, configurationBuilder) =>
                     {
                         //Configuration
                         hostBuilderContext.HostingEnvironment.EnvironmentName = System.Environment.GetEnvironmentVariable("NETCORE_ENVIRONMENT");
                         var env = hostBuilderContext.HostingEnvironment;
                         configurationBuilder.AddEnvironmentVariables();
                         configurationBuilder.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                         configurationBuilder.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: false, reloadOnChange: true);
                     })
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
                         //Connection for EF database + DbContext
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
                         //Forms
                         serviceCollection.AddSingleton<FormMainMenu>();
                         serviceCollection.AddSingleton<ServiceArgs>();
                         serviceCollection.AddTransient<AllEventsForm>();
                         serviceCollection.AddTransient<CategoryForm>();
                         serviceCollection.AddTransient<DetaisOfEventForm>();
                         serviceCollection.AddTransient<ForumForm>();
                         serviceCollection.AddTransient<GalleryForm>();
                         serviceCollection.AddTransient<ProfileForm>();
                     })
                     .ConfigureLogging((hostBuilderContext, loggingBuilder) =>
                     {
                     })
                     .Build();

            var FormMainMenuSVC = host.Services.GetRequiredService<FormMainMenu>();
            Application.Run(FormMainMenuSVC);
        }
    }
}