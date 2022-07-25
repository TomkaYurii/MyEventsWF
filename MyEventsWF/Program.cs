using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyEventsAdoNetDB.Repositories;
using MyEventsAdoNetDB.Repositories.Interfaces;
using MyEventsWF.Forms;
using System.Data;
using System.Data.SqlClient;
using MyEventsEntityFrameworkDb.Context;

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
                     .ConfigureAppConfiguration((hostingContext, config) =>
                     {
                         //Configuration
                         var env = hostingContext.HostingEnvironment;
                         config.AddEnvironmentVariables();
                         config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                         config.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: false, reloadOnChange: true);
                     })
                     .ConfigureServices((hostContext, services) =>
                     {
                         // Connection/Transaction for database
                         services.AddScoped((s) => new SqlConnection(hostContext.Configuration.GetConnectionString("MSSQLConnection")));
                         services.AddScoped<IDbTransaction>(s =>
                         {
                             SqlConnection conn = s.GetRequiredService<SqlConnection>();
                             conn.Open();
                             return conn.BeginTransaction();
                         });
                         // Dependendency Injection for Repositories/UOF from DAL
                         services.AddScoped<IEventRepository, EventRepository>();
                         services.AddScoped<ICategoryRepository, CategoryRepository>();
                         services.AddScoped<IUserProfileRepository, UserProfileRepository>();
                         services.AddScoped<IGalleryRepository, GalleryRepository>();
                         services.AddScoped<IMessageRepository, MessageRepository>();
                         services.AddScoped<IUnitOfWork, UnitOfWork>();
                         //Forms
                         services.AddSingleton<FormMainMenu>();
                         services.AddTransient<AllEventsForm>();
                         services.AddTransient<CategoryForm>();
                         services.AddTransient<DetaisOfEventForm>();
                         services.AddTransient<ForumForm>();
                         services.AddTransient<GalleryForm>();
                         services.AddTransient<ProfileForm>();
                     })

                     .ConfigureLogging(logging =>
                     {
                         // Add other loggers...
                     })
                     .Build();

            //using IServiceScope serviceScope = host.Services.CreateScope();
            //IServiceProvider provider = serviceScope.ServiceProvider;
            //var FormMainMenuSVC = provider.GetRequiredService<FormMainMenu>();
            var services = host.Services;
            var FormMainMenuSVC = services.GetRequiredService<FormMainMenu>();

            Application.Run(FormMainMenuSVC);
        }
    }
}