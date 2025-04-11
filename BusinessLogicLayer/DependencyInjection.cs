using BusinessLogicLayer.ServiceContracts;
using BusinessLogicLayer.Services;
using BusinessLogicLayer.Stores;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessLogicLayer
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddBusinessLogicLayer(this IServiceCollection services)
        {
            services.AddScoped<ITestService, TestService>();
            services.AddScoped<ILoginService, LoginService>();
            services.AddSingleton<IVerifierStore, VerifierStore>();

            return services;
        }
    }
}
