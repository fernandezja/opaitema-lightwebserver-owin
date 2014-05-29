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
            //Set up via input parameters
            ConfigInitWithParameters(args);

            using (Microsoft.Owin.Hosting.WebApp.Start<StartupForOwin>(Config.Instance.Uri))
            {
                Console.WriteLine("Opaitema LightWebserver on {0} is up.", Config.Instance.Uri);
                Console.ReadKey();
                
            }

            Console.WriteLine("Opaitema LightWebserver on {0} is close.", Config.Instance.Uri);
            Console.WriteLine("Press any key for close.");
            Console.ReadKey();

        }

        static void ConfigInitWithParameters(string[] args) {
            var folder = string.Empty;
            int port = 9090;
            var debugRequest = false;
            var defaultDocument = string.Empty;

            //Argumentos
            for (int i = 0; i < args.Length; i++)
            {
                var param = args[i].Trim().ToLower();

                //Validate is directory exists
                //Parameter: -f: folder
                if (param.IndexOf("-f:") > -1 || param.IndexOf("/f:") > -1)
                {
                    folder = param.Substring(3, param.Length - 3);
                    if (!System.IO.Directory.Exists(folder))
                        throw new Exception(String.Format("The directory not exists {0}", folder));
                }

                //Parameter: -p: port
                if (param.IndexOf("-p:") > -1 || param.IndexOf("/p:") > -1)
                {
                    var portCadena = param.Substring(3, param.Length - 3);
                    if (!Int32.TryParse(portCadena, out port))
                        throw new Exception("You must enter a number for the http port");
                }

                //Parameter: -debug: debugRequest
                if (param.IndexOf("-debug:") > -1 || param.IndexOf("/debug:") > -1)
                {
                    var debugRequestCadena = param.Substring(7, param.Length - 7);
                    if (!Boolean.TryParse(debugRequestCadena, out debugRequest))
                        throw new Exception("You must enter a Boolean value for debugRequest parameter");
                }

                //Parameter: -d: Default Document
                if (param.IndexOf("-d:") > -1 || param.IndexOf("/d:") > -1)
                {
                    defaultDocument = param.Substring(3, param.Length - 3);
                }
            }

            Config.Instance.RootDirectory = String.IsNullOrEmpty(folder)
                                                ? Environment.CurrentDirectory
                                                : folder;


            Config.Instance.DefaultDocument = String.IsNullOrEmpty(defaultDocument)
                                                ? "index.html"
                                                : defaultDocument;

            

            Config.Instance.Port = port;
            Config.Instance.DebugRequest = debugRequest;

        }
    }
}
