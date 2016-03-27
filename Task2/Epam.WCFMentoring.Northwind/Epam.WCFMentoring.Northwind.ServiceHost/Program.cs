using Epam.WCFMentoring.Northwind.ServicesImpl.CategorySvc;
using Epam.WCFMentoring.Northwind.ServicesImpl.OrderSvc;
using System;
using System.Diagnostics;
using System.ServiceModel;

namespace Epam.WCFMentoring.Northwind.ConsoleServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {
            Debug.Listeners.Add(new ConsoleTraceListener());

            using (var orderHost = new ServiceHost(typeof(OrderServiceImpl)))
            using (var pubSubHost = new ServiceHost(typeof(PubSubServiceImpl)))
            using (var categoryHost = new ServiceHost(typeof(CategoryServiceImpl)))
            {
                pubSubHost.Open();
                orderHost.Open();
                categoryHost.Open();
                Debug.Print("Host is running");

                Console.WriteLine("Press any key to stop host");
                Console.ReadKey();

                pubSubHost.Close();
                orderHost.Close();
                categoryHost.Close();
                Console.WriteLine("Host stopped");
            }
        }
    }
}
