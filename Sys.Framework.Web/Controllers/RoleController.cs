using Sys.Framework.Model.Sys;
using Sys.Framework.Service.Sys;
using Sys.Framework.Web.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sys.Framework.Web.Controllers
{
    public class RoleController : BaseController
    {
        #region 构造函数
        private IRoleService _roleService;
        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }
        #endregion
        #region 角色首页
        /// <summary>
        /// 角色首页
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
                var rows = _roleService.GetData(pageIndex, pageSize, key, out total);
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
        #region 编辑
        /// <summary>
        /// 编辑页面
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Edit(int id)
        {
            var role = _roleService.GetModel(o => o.F_Id == id);
            return View(role);
        }
        /// <summary>
        /// 编辑提交
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Edit(T_Sys_Role role)
        {
            Dictionary<string, object> result = new Dictionary<string, object>();
            result.Add("success", true);
            if (string.IsNullOrEmpty(role.F_RoleName))
            {
                result["success"] = false;
                result.Add("msg", "角色名称不能为空！");
            }
            else
            {
                int b = _roleService.Update(role);
                if (b == 0)
                {
                    result["success"] = false;
                    result.Add("msg", "修改失败！");
                }
            }
            return Json(result);
        }
        #endregion
    }
}