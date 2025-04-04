using BusinessLogicLayer.ServiceContracts;
using BusinessLogicLayer.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BusinessLogicLayer
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddBusinessLogicLayer(this IServiceCollection services)
        {
            services.AddScoped<ITestService, TestService>();
            services.AddScoped<ILoginService, LoginService>();

            return services;
        }
    }
}
