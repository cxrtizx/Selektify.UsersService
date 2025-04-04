using BusinessLogicLayer.ServiceContracts;
using Microsoft.Extensions.DependencyInjection;
using PresentationLayer;

var serviceCollection = new ServiceCollection();
BusinessLogicLayer.DependencyInjection.AddBusinessLogicLayer(serviceCollection);
var serviceProvider = serviceCollection.BuildServiceProvider();
var service = serviceProvider.GetRequiredService<ILoginService>();
service.Login();

UserMenu.ProcessInput();