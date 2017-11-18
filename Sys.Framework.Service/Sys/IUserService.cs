using Sys.Framework.Model.Sys;
using Sys.Framework.Service.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Sys.Framework.Service.Sys
{
    public interface IUserService
    {
        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="isSave"></param>
        /// <returns></returns>
        int Insert(T_Sys_User entity, bool isSave = true);
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="isSave"></param>
        /// <returns></returns>
        int Update(T_Sys_User entity, bool isSave = true);
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="whereLambds"></param>
        /// <param name="isSave"></param>
        /// <returns></returns>
        int DeleteById(Expression<Func<T_Sys_User, bool>> whereLambds, bool isSave = true);
        /// <summary>
        /// 查询
        /// </summary>
        /// <typeparam name="S"></typeparam>
        /// <param name="whereLambds"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="totalItem"></param>
        /// <param name="orderByLambds"></param>
        /// <param name="isAsc"></param>
        /// <returns></returns>
        IEnumerable<T_Sys_User> GetAllPaged<S>(Expression<Func<T_Sys_User, bool>> whereLambds, int pageIndex, int pageSize, out int totalItem, Expression<Func<T_Sys_User, S>> orderByLambds, bool isAsc = true);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="S"></typeparam>
        /// <param name="whereLambds"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="totalItem"></param>
        /// <param name="orderByLambds"></param>
        /// <param name="isAsc"></param>
        /// <returns></returns>
        IEnumerable<T_Sys_User> GetUserData(int pageIndex, int pageSize, string key, out int totalItem, bool isAsc = true);


        /// <summary>
        /// 执行SQL
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        IEnumerable<T_Sys_User> SqlQuery(string sql, params object[] parameters);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        T_Sys_User GetModel(Expression<Func<T_Sys_User, bool>> where);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="userPwd"></param>
        /// <returns></returns>
        LoginValidate LoginValidateInfo(string Account, string Password);
    }
}
