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
                         // Connection/Transaction for database
                         serviceCollection.AddScoped((s) => new SqlConnection(hostBuilderContext.Configuration.GetConnectionString("MSSQLConnection")));
                         serviceCollection.AddScoped<IDbTransaction>(s =>
                         {
                             SqlConnection conn = s.GetRequiredService<SqlConnection>();
                             conn.Open();
                             return conn.BeginTransaction();
                         });
                         // Dependendency Injection for Repositories/UOF from ADO.NET/EF DAL
                         serviceCollection.AddScoped<IEventRepository, EventRepository>();
                         serviceCollection.AddScoped<ICategoryRepository, CategoryRepository>();
                         serviceCollection.AddScoped<IUserProfileRepository, UserProfileRepository>();
                         serviceCollection.AddScoped<IGalleryRepository, GalleryRepository>();
                         serviceCollection.AddScoped<IMessageRepository, MessageRepository>();
                         serviceCollection.AddScoped<IImageRepository, ImageRepository>();
                         serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
                         //Forms
                         serviceCollection.AddSingleton<FormMainMenu>();
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

            //using IServiceScope serviceScope = host.Services.CreateScope();
            //IServiceProvider provider = serviceScope.ServiceProvider;
            //var FormMainMenuSVC = provider.GetRequiredService<FormMainMenu>();

            var FormMainMenuSVC = host.Services.GetRequiredService<FormMainMenu>();

            Application.Run(FormMainMenuSVC);
        }
    }
}