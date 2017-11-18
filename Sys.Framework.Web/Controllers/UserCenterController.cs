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
    public class UserCenterController : BaseController
    {
        #region 构造函数
        private IUserService _userService;
        private IRoleService _roleService;
        public UserCenterController(IUserService userService, IRoleService roleService)
        {
            _userService = userService;
            _roleService = roleService;
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
        public ActionResult GetUserData()
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
                var rows = _userService.GetUserData(pageIndex, pageSize, key, out total);
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
        #region 修改密码
        /// <summary>
        /// 修改密码页面
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult ModifyPassword(int id)
        {
            var user = _userService.GetModel(o => o.F_Id == id);
            return View(user);
        }
        /// <summary>
        /// 修改密码提交
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ModifyPassword(T_Sys_User user)
        {
            Dictionary<string, object> result = new Dictionary<string, object>();
            result.Add("success", true);
            string oldPassword = Request.Form["OldPassword"].ToString().Trim();
            string newPassowrd = Request.Form["NewPassowrd"].ToString().Trim();
            string newPassword2 = Request.Form["NewPassword2"].ToString().Trim();
            var resultUser = _userService.GetModel(o => o.F_Id == user.F_Id && o.F_Password == oldPassword);
            if (resultUser == null)
            {
                result["success"] = false;
                result.Add("msg", "原始密码不正确！");
            }
            else if (!newPassowrd.Equals(newPassword2))
            {
                result["success"] = false;
                result.Add("msg", "输入两次密码不一致！");
            }
            else
            {
                resultUser.F_Password = newPassword2;
                int b = _userService.Update(resultUser);
                if (b == 0)
                {
                    result["success"] = false;
                    result.Add("msg", "密码修改失败！");
                }
            }
            return Json(result);
        }
        #endregion
        #region 修改
        /// <summary>
        /// 修改页面
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Edit(int id)
        {
            var user = _userService.GetModel(o => o.F_Id == id);
            return View(user);
        }
        /// <summary>
        /// 修改提交
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Edit(T_Sys_User user)
        {
            Dictionary<string, object> result = new Dictionary<string, object>();
            result.Add("success", true);
            if (string.IsNullOrEmpty(user.F_Account))
            {
                result["success"] = false;
                result.Add("msg", "用户名不能为空！");
            }
            else
            {
                int b = _userService.Update(user);
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