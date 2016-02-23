using Microsoft.AspNet.Routing;
using Microsoft.AspNet.Routing.Template;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Microsoft.AspNet.Builder
{
    public static class ConfigurationExtensions
    {
        public static IRouteBuilder MapMicroGardenSettings(this IRouteBuilder builder, string prefix = "settings")
        {
            var constraintResolver = (IInlineConstraintResolver)builder.ServiceProvider.GetService(typeof(IInlineConstraintResolver));

            builder.Routes.Add(new TemplateRoute(new RestRoute(builder.DefaultHandler),
                "Settings", prefix + "/api/{controller}/{id?}",
                new Dictionary<string, object> { },
                new Dictionary<string, object> { },
                new Dictionary<string, object> { { "namespaces", new[] { "MicroGarden.Settings.AspNetCore.Api.Schemas" } } },
                constraintResolver));

            return builder;
        }

        private class RestRoute : IRouter
        {
            readonly IRouter _target;

            public RestRoute(IRouter target)
            {
                _target = target;
            }

            public VirtualPathData GetVirtualPath(VirtualPathContext context)
            {
                return null;
            }

            public Task RouteAsync(RouteContext context)
            {
                if (!context.RouteData.Values.ContainsKey("action"))
                {
                    if (context.RouteData.Values.ContainsKey("id")
                        && context.HttpContext.Request.Method == "GET")
                    {
                        context.RouteData.Values["action"] = "Item";
                    }
                    else
                    {
                        context.RouteData.Values["action"] = context.HttpContext.Request.Method;
                    }
                }

                return _target.RouteAsync(context);
            }
        }


    }
}
