using System.Web.Http.Filters;
using Logger;

namespace Web.App_Start
{
    public class LogExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            var ex = context.Exception;
            LoggerContext.Instance.Fatal($"Message: {ex.Message} + Source: {ex.Source} + StackTrace: {ex.StackTrace}");
        }
    }
}