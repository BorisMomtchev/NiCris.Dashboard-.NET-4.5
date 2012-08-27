﻿using NiCris.Web.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace NiCris.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Filters.Add(new ValidateAttribute());

            //IKernel kernel = new StandardKernel();
            //kernel.Bind<ICommentRepository>().ToConstant(new InitialData());
            //config.DependencyResolver = new NinjectResolver(kernel);

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
