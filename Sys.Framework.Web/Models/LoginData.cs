using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sys.Framework.Web.Models
{
    public class LoginData
    {
        public bool IsOk { get; set; }

        public string Msg { get; set; }

        public object Data { get; set; }
    }
}