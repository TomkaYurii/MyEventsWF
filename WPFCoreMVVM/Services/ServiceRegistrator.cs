using Microsoft.Extensions.DependencyInjection;
using WPFCoreMVVM.Services.Interfaces;

namespace WPFCoreMVVM.Services
{
    internal static class ServiceRegistrator
    {
        public static IServiceCollection AddServices(this IServiceCollection services) => services
           .AddTransient<IDataService, DataService>()
           .AddTransient<IUserDialog, UserDialog>()
        ;
    }
}
