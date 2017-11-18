using Sys.Framework.Service.Sys;
using Sys.Framework.Web.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sys.Framework.Web.Controllers
{
    public class AcceptController : BaseController
    {
        #region 构造函数
        private IAcceptService _acceptService;
        public AcceptController(IAcceptService acceptService)
        {
            _acceptService = acceptService;
        }
        #endregion
        #region 用户管理页面
        /// <summary>
        /// 用户管理页面
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }
        #endregion
        #region 获取数据
        /// <summary>
        /// 获取数据
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult GetData()
        {
            var result = new Dictionary<string, object>();
            var limit = Convert.ToInt32(Request.Form["limit"]);//每页的个数
            var offset = Convert.ToInt32(Request.Form["offset"]);//分页时数据的偏移量
            //var order = Request.QueryString["order"].ToString();//排序 asc desc
            var key = Request.Form["key"] == null ? "" : Request.Form["key"].ToString();//搜索关键字
            var pageSize = limit;
            var pageIndex = offset / limit + 1;
            try
            {
                int total = 0;
                var rows = _acceptService.GetData(pageIndex, pageSize, key, out total);
                result.Add("rows", rows);
                result.Add("total", total);
                result.Add("IsOk", true);
            }
            catch (Exception ex)
            {
                result.Add("IsOk", false);
            }
            return Json(result);
        }
        #endregion


    }
}