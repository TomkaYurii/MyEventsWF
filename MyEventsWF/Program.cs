using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyEventsAdoNetDB.Repositories;
using MyEventsAdoNetDB.Repositories.Interfaces;
using MyEventsWF.Forms;
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
                     .ConfigureAppConfiguration((hostContext, config) =>
                     {
                         //Configuration
                         hostContext.HostingEnvironment.EnvironmentName = System.Environment.GetEnvironmentVariable("NETCORE_ENVIRONMENT");
                         var env = hostContext.HostingEnvironment;
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
                         // Dependendency Injection for Repositories/UOF from ADO.NET/EF DAL
                         services.AddScoped<IEventRepository, EventRepository>();
                         services.AddScoped<ICategoryRepository, CategoryRepository>();
                         services.AddScoped<IUserProfileRepository, UserProfileRepository>();
                         services.AddScoped<IGalleryRepository, GalleryRepository>();
                         services.AddScoped<IMessageRepository, MessageRepository>();
                         services.AddScoped<IImageRepository, ImageRepository>();
                         services.AddScoped<IUnitOfWork, UnitOfWork>();
                         //Forms
                         services.AddScoped<FormMainMenu>();
                         services.AddScoped<AllEventsForm>();
                         services.AddScoped<CategoryForm>();
                         services.AddScoped<DetaisOfEventForm>();
                         services.AddScoped<ForumForm>();
                         services.AddScoped<GalleryForm>();
                         services.AddScoped<ProfileForm>();
                     })

                     .ConfigureLogging(logging =>
                     {
                         // Add other loggers...
                     })
                     .Build();

            using IServiceScope serviceScope = host.Services.CreateScope();
            IServiceProvider provider = serviceScope.ServiceProvider;
            var FormMainMenuSVC = provider.GetRequiredService<FormMainMenu>();

            Application.Run(FormMainMenuSVC);
        }
    }
}