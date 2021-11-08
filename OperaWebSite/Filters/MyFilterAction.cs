using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OperaWebSite.Filters
{
    public class MyFilterAction : ActionFilterAttribute
    {
        //public override void OnActionExecuted(ActionExecutedContext filterContext)
        //{
        //    base.OnActionExecuted(filterContext);
        //}

        //public override void OnActionExecuting(ActionExecutingContext filterContext)
        //{
        //    base.OnActionExecuting(filterContext);
        //}

        //Filtro de accion - ANTES
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //controller/action
            //{controller}/{action}
            //Opera/create
            var controller = filterContext.RouteData.Values["controller"];
            var action = filterContext.RouteData.Values["action"];
            Debug.WriteLine("Controller: " + controller + " Action:" + action + " Paso por OnActionExecuted");
        }

        //Filtro de accion - DESPUES
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            //controller/action
            //{controller}/{action}
            //Opera/create
            var controller = filterContext.RouteData.Values["controller"];
            var action = filterContext.RouteData.Values["action"];
            Debug.WriteLine("Controller: " + controller + " Action:" + action + " Paso por OnActionExecuted");
        }


    }
}