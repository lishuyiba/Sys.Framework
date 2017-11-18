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
    public class BusinessController : BaseController
    {
        #region 构造函数
        private IBusinessService _businessService;
        public BusinessController(IBusinessService businessService)
        {
            _businessService = businessService;
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
                var rows = _businessService.GetData(pageIndex, pageSize, key, out total);
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
        public ActionResult Edit(int id)
        {
            var model = _businessService.GetModel(o => o.F_Id == id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(T_Sys_Business model)
        {
            Dictionary<string, object> result = new Dictionary<string, object>();
            result.Add("success", true);
            try
            {
                int resultUpdate = _businessService.Update(model);
                if (resultUpdate == 0)
                {
                    result["success"] = false;
                }
            }
            catch (Exception ex)
            {
                result["success"] = false;
            }
            return Json(result);
        }
        #endregion

        #region 添加
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(T_Sys_Business model)
        {
            Dictionary<string, object> result = new Dictionary<string, object>();
            result.Add("success", true);
            try
            {
                model.F_CreateTime = DateTime.Now;
                int resultInsert = _businessService.Insert(model);
                if (resultInsert == 0)
                {
                    result["success"] = false;
                }
            }
            catch (Exception ex)
            {
                result["success"] = false;
            }
            return Json(result);
        }
        #endregion

        #region 删除
        [HttpPost]
        public ActionResult Delete()
        {
            Dictionary<string, object> result = new Dictionary<string, object>();
            result.Add("success", true);
            try
            {
                string[] ids = Request.Form["ids"].Split(',');
                foreach (var id in ids)
                {
                    int deleteId = Convert.ToInt32(id);
                    int resultDelete = _businessService.DeleteById(o => o.F_Id == deleteId);
                    if (resultDelete == 0)
                    {
                        result["success"] = false;
                    }
                }
            }
            catch (Exception ex)
            {
                result["success"] = false;

            }
            return Json(result);
        }
        #endregion
    }
}