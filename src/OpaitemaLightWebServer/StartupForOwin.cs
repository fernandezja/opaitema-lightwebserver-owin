using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using System.IO;

[assembly: OwinStartup(typeof(OpaitemaLightWebServer.StartupForOwin))]

namespace OpaitemaLightWebServer
{
    public class StartupForOwin
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888

            app.Run(context =>
            {
                //File Request
                var path = context.Request.Path.ToString();

                //Verify that it is a directory (at the end "/")
                if (path.ToString().Substring(path.ToString().Length-1, 1)=="/")
                {
                    path = String.Concat(path, Config.Instance.DefaultDocument);
                }


                var filePath = Path.Combine(Config.Instance.RootDirectory, path.ToString().Substring(1, path.ToString().Length - 1).Replace("/", "\\"));


                if (File.Exists(filePath))
                {
                    if (Config.Instance.DebugRequest)
                        Console.WriteLine("Request: {0}", path);


                    context.Response.ContentType = Config.Instance.GetMimeFromExtension(Path.GetExtension(filePath));

                    var file = File.ReadAllBytes(filePath);
                    //context.Response.ContentType = "text/plain";
                    return context.Response.WriteAsync(file);
                }
                else
                {
                    if (Config.Instance.DebugRequest)
                        Console.WriteLine("Request invalid: {0} (File not found)", path);

                    context.Response.ContentType = "text/plain";
                    context.Response.StatusCode = 404;
                    return context.Response.WriteAsync("File not found");
                }

                


                //context.Response.ContentType = "text/plain";
                //return context.Response.WriteAsync("Opaitema LightWebserver is up!");
            });

        }
    }
}
