using System;
using Microsoft.Extensions.DependencyInjection;

namespace di
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new ServiceCollection()
                .AddTransient<IGreeting, GreetingService>()
                .BuildServiceProvider();

            var service = container.GetService<IGreeting>();

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
