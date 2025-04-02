using BusinessLogicLayer.ServiceContracts;
using Microsoft.Extensions.DependencyInjection;

var serviceCollection = new ServiceCollection();
BusinessLogicLayer.DependencyInjection.AddBusinessLogicLayer(serviceCollection);
var serviceProvider = serviceCollection.BuildServiceProvider();
var service = serviceProvider.GetRequiredService<ITestService>();
service.Run();

