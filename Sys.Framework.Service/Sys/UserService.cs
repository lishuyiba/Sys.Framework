using Sys.Framework.Data.EntityFramework;
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
    public class UserService : IUserService
    {
        private readonly IRepository<T_Sys_User> _repository;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="repository"></param>
        public UserService(IRepository<T_Sys_User> repository)
        {
            _repository = repository;
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="whereLambds"></param>
        /// <param name="isSave"></param>
        /// <returns></returns>
        public int DeleteById(Expression<Func<T_Sys_User, bool>> whereLambds, bool isSave = true)
        {
            return _repository.DeleteById(whereLambds, isSave);
        }

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
        public IEnumerable<T_Sys_User> GetAllPaged<S>(Expression<Func<T_Sys_User, bool>> whereLambds, int pageIndex, int pageSize, out int totalItem, Expression<Func<T_Sys_User, S>> orderByLambds, bool isAsc = true)
        {
            return _repository.GetAllPaged(whereLambds, pageIndex, pageSize, out totalItem, orderByLambds, isAsc);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public T_Sys_User GetModel(Expression<Func<T_Sys_User, bool>> where)
        {
            return _repository.GetModel(where);
        }

        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="isSave"></param>
        /// <returns></returns>
        public int Insert(T_Sys_User entity, bool isSave = true)
        {
            return _repository.Insert(entity, isSave);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public IEnumerable<T_Sys_User> SqlQuery(string sql, params object[] parameters)
        {
            return _repository.SqlQuery(sql, parameters);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="isSave"></param>
        /// <returns></returns>
        public int Update(T_Sys_User entity, bool isSave = true)
        {
            return _repository.Update(entity, isSave);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        public LoginValidate LoginValidateInfo(string Account, string Password)
        {
            if (_repository.GetModel(o => o.F_Account.Equals(Account)) == null)
            {
                return LoginValidate.NameNotExist;
            }
            if (_repository.GetModel(o => o.F_Account.Equals(Account) && o.F_Password.Equals(Password)) == null)
            {
                return LoginValidate.PasswordError;
            }
            return LoginValidate.OK;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="key"></param>
        /// <param name="totalItem"></param>
        /// <param name="isAsc"></param>
        /// <returns></returns>
        public IEnumerable<T_Sys_User> GetUserData(int pageIndex, int pageSize, string key, out int totalItem, bool isAsc = true)
        {
            if (!string.IsNullOrEmpty(key))
            {
                return _repository.GetAllPaged(o => o.F_Account.Contains(key), pageIndex, pageSize, out totalItem, o => o.F_CreateTime, isAsc);
            }
            return _repository.GetAllPaged(o => o.F_IsDelete == 0, pageIndex, pageSize, out totalItem, o => o.F_CreateTime, isAsc);
        }
    }
}
