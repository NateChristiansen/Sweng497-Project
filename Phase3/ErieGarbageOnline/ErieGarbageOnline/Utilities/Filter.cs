using System.Linq;
using System.Web.Mvc;
using ErieGarbageOnline.Models;
using ErieGarbageOnline.Models.DatabaseModels;

namespace ErieGarbageOnline.Utilities
{
    public class Filter : ActionFilterAttribute
    {
        private readonly FilterType _filter;
        private readonly EGODatabase _database = EGODatabase.Create();

        public Filter(FilterType filterType)
        {
            _filter = filterType;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // check if there is a session and a user, if not block access
            if (filterContext.HttpContext.Session != null && filterContext.HttpContext.Session["User"] == null)
            {
                filterContext.Result = new UnauthorizedResult();
                return;
            }
            
            var user = filterContext.HttpContext.Session?["User"] as LoginModel;
            // if user is not correct model, block access
            if (user == null)
            {
                filterContext.Result = new UnauthorizedResult();
                return;
            }
            
            // check if user is in admin database before giving access to admin screen
            if (_filter == FilterType.Admin)
            {
                if (_database.Admins.Any(admin => admin.Email.Equals(user.Email)))
                {
                    base.OnActionExecuting(filterContext);
                    return;
                }
            }
            // like above but for customer
            if (_filter == FilterType.Customer)
            {
                if (_database.Customers.Any(customer => customer.Email.Equals(user.Email)))
                {
                    base.OnActionExecuting(filterContext);
                    return;
                }
            }
            filterContext.Result = new UnauthorizedResult();
        }
    }

    public enum FilterType
    {
        Admin,
        Customer
    }

    public class UnauthorizedResult : ActionResult
    {
        public override void ExecuteResult(ControllerContext context)
        {
            context.RequestContext.HttpContext.Response.RedirectToRoute(new {controller="Login", action="Index"});
        }
    }
}