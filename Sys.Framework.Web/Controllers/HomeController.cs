using Sys.Framework.Service.Sys;
using Sys.Framework.Web.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sys.Framework.Web.Controllers
{
    public class HomeController : BaseController
    {
        #region 构造函数
        private IUserService _userService;
        public HomeController(IUserService userService)
        {
            _userService = userService;
        }
        #endregion
        #region 系统首页
        /// <summary>
        /// 系统首页
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            int total = 0;
            var query1 = _userService.SqlQuery("SELECT * FROM T_Sys_User").ToList();
            var query2 = _userService.GetAllPaged(where => where.F_Id > 0, 1, 100, out total, order => order.F_CreateTime, false);

            return View();
        }
        #endregion
        #region 获取数据
        /// <summary>
        /// 获取数据
        /// </summary>
        /// <returns></returns>
        public ActionResult GetData()
        {
            int total = 0;
            var query = _userService.GetAllPaged(where => where.F_Id > 0, 1, 100,
                out total, order => order.F_CreateTime, false);
            return Json(query, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}