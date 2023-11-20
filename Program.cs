using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace DepInj2
{
    public class Program
    {
        public void Main()
        {
            var host = new HostBuilder()
            .ConfigureFunctionsWorkerDefaults()
            .ConfigureServices(services =>
            {
                services.AddApplicationInsightsTelemetryWorkerService();
                services.ConfigureFunctionsApplicationInsights();
                services.AddTransient(sp => {
                    return new MyClass();
                });
            })
            .Build();

            host.Run();
        }
    }

    public class MyClass
    {
        public MyClass()
        {
            System.Console.WriteLine("Initiating MyClass!!!");
        }
    }
}
