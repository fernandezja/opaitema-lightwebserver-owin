using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpaitemaLightWebServer
{
    class Program
    {
        static void Main(string[] args)
        {
            //TODO: Only Test... Should set up via input parameters
            int port = 9090; 
            string uri = String.Format("http://localhost:{0}/", port);

            using (Microsoft.Owin.Hosting.WebApp.Start<StartupForOwin>(uri))
            {
                Console.WriteLine("Opaitema LightWebserver on {0} is up.", uri);
                Console.ReadKey();
                
            }

            Console.WriteLine("Opaitema LightWebserver on {0} is close.", uri);
            Console.WriteLine("Press any key for close.");
            Console.ReadKey();

        }
    }
}
