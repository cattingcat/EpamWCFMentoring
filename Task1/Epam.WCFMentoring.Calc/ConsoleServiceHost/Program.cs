using System;
using System.ServiceModel;
using System.Diagnostics;

using ServicesImpl;

namespace ConsoleServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var host = new ServiceHost(typeof(CalcServiceImpl)))
            {
                host.Open();
                Debug.Print("Host is running");

                Console.WriteLine("Press any key to stop host");
                Console.ReadKey();

                host.Close();
                Console.WriteLine("Host stopped");
            }

            
            
        }
    }
}
