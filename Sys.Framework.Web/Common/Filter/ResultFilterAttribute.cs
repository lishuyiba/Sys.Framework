using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sys.Framework.Web.Common.Filter
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
    public class ResultFilterAttribute : System.Web.Mvc.ActionFilterAttribute, IResultFilter
    {
        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            if (filterContext.Result.GetType() == typeof(JsonResult))
            {
                HttpResponseBase response = filterContext.HttpContext.Response;
                JsonResult result = filterContext.Result as JsonResult;
                response.Clear();
                string jsonData = JsonConvert.SerializeObject(result.Data, new IsoDateTimeConverter() { DateTimeFormat = "yyyy-MM-dd HH:mm:ss" });
                response.Write(jsonData);
            }
        }
    }
}