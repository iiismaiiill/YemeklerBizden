using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace yemekoneri.LoginFilter
{
    public class FilterContext : ActionFilterAttribute, IActionFilter
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var userCookie = filterContext.HttpContext.Request.Cookies["User"];
            var userIdCookie = filterContext.HttpContext.Request.Cookies["UserId"];

            var controllerName = filterContext.ActionDescriptor.RouteValues["controller"].ToString();
            var actionName = filterContext.ActionDescriptor.RouteValues["action"].ToString();

            if (userCookie == null)
            {
                if (actionName != "Index")
                {

                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Home" }, { "action", "Index" } });
                }
            }

            base.OnActionExecuting(filterContext);
        }
    }
}
