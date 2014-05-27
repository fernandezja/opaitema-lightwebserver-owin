﻿using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

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
                context.Response.ContentType = "text/plain";
                return context.Response.WriteAsync("Opaitema LightWebserver is up!");
            });

        }
    }
}
