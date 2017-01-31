﻿using Microsoft.Owin.Hosting;
using System;
using Owin;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using QX_Frame.App.Web.Extends;

namespace QX_Frame.Web.Srv
{
    /**
     * author:qixiao
     * time:2017-1-31 19:20:27
     **/ 
    class Program
    {
        static void Main(string[] args)
        {
            //string baseAddress = "http://localhost:3999/";    //localhost visit
            string baseAddress = "http://+:3999/";              //all internet environment visit  
            try
            {
                WebApp.Start<StartUp>(url: baseAddress);
                Console.WriteLine("baseAddress:"+baseAddress);
                Console.WriteLine("Application Started ...");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            for (;;)
            {
                Console.ReadLine();
            }
        }
    }
    //the start up configuration
    class StartUp
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            HttpConfiguration config = new HttpConfiguration();

            // Web API configuration and services
            //跨域配置
            //config.EnableCors(new EnableCorsAttribute("*", "*", "*"));
            // Web API routes

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional },
                 namespaces: new string[] { "QX_Frame.WebAPI.Controllers" }
            );
            config.Services.Replace(typeof(IHttpControllerSelector), new WebAPI.WebApiControllerSelector(config));

            //if config the global filter input there need not write the attributes
            //config.Filters.Add(new App.Web.Filters.ExceptionAttribute_DG());

            appBuilder.UseWebApi(config);

        }
    }
}
