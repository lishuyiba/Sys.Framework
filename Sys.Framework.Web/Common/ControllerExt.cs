using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sys.Framework.Web.Common
{
    public static class ControllerExt
    {
        public static void Msg(this Controller controller, string msg, string key = "msg")
        {
            controller.ViewData[key] = msg;
        }
    }
}