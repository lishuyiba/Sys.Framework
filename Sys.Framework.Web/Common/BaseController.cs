using Sys.Framework.Web.Common.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sys.Framework.Web.Common
{
    [ResultFilterAttribute]
    public class BaseController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var userInfo = Session["userInfo"];
            if (userInfo == null)
            {
                filterContext.Result = new RedirectResult("/User/Login?ReturnUrl=" + filterContext.HttpContext.Request.Path);
            }
            ViewData["MyUserInfo"] = userInfo;
            base.OnActionExecuting(filterContext);
        }
    }
}