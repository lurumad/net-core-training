using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace autofac
{
    class Program
    {
        static void Main(string[] args)
        {
            var services = new ServiceCollection();

            var builder = new ContainerBuilder();
            builder.Populate(services);
            builder.RegisterType<GreetingService>().As<IGreeting>();
            var container = builder.Build();
            var serviceProvider = new AutofacServiceProvider(container);

            var service = serviceProvider.GetService<IGreeting>();

            Console.WriteLine(service.SayHello());
            Console.Read();
        }   
    }

    interface IGreeting
    {
        string SayHello();
    }

    class GreetingService : IGreeting
    {
        public string SayHello()
        {
            return "Hello veinteractive.com";
        }
    }
}
