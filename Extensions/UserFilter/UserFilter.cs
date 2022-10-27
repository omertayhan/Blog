using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Blog.Extensions.UserFilter
{
    public class UserFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            int? userId = context.HttpContext.Session.GetInt32("id");
            int? adminId = context.HttpContext.Session.GetInt32("admin");
            if (!userId.HasValue && !adminId.HasValue)
            {
                context.Result = new RedirectToActionResult("Index", "Home", "/Home/Index");
            }
        }
    }
}
