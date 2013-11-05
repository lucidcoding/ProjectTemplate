using System.Web.Mvc;
using log4net;

namespace ProjectTemplate.UI.ActionFilters
{
    public class LogAttribute : ActionFilterAttribute
    {
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public LogAttribute()
        {
            Order = 1020;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Log.Info(
                "Request: User: " + filterContext.HttpContext.User.Identity.Name 
                + (filterContext.HttpContext.Request.Url != null ? "; URL: " + filterContext.HttpContext.Request.Url.AbsolutePath : "")
                + "; Data: " + filterContext.HttpContext.Request.Form);
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if(filterContext.Exception != null)
            {
                Log.Error("Error executing action: " + filterContext.Exception.Message, filterContext.Exception);
            }
        }
    }
}