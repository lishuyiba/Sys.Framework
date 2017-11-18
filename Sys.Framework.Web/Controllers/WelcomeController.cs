using Sys.Framework.Web.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sys.Framework.Web.Controllers
{
    public class WelcomeController : BaseController
    {
        // GET: Welcome
        public ActionResult Index()
        {
            return View();
        }
    }
}