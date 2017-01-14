using System.Web.Mvc;

namespace MVC.Infrastructure.Filters
{
    public class ExceptionFilter : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            filterContext.Result = new ViewResult
            {
                ViewName = "Error",
            };
            filterContext.ExceptionHandled = true;           
        }
    }
}