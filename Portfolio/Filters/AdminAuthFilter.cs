using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Http;

namespace Portfolio.Filters
{
    public class AdminAuthFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var adminUser = context.HttpContext.Session.GetString("AdminUser");
            
            if (string.IsNullOrEmpty(adminUser))
            {
                // Session yoksa login sayfasına yönlendir
                context.Result = new RedirectToActionResult("Index", "Login", null);
                return;
            }

            // Tarayıcı önbelleğini engelle
            var response = context.HttpContext.Response;
            response.Headers["Cache-Control"] = "no-cache, no-store, must-revalidate";
            response.Headers["Pragma"] = "no-cache";
            response.Headers["Expires"] = "0";
            
            base.OnActionExecuting(context);
        }
    }
} 