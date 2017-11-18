using Sys.Framework.Data.EntityFramework;
using Sys.Framework.Model.Sys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Sys.Framework.Service.Sys
{
    public class RoleService : IRoleService
    {
        private readonly IRepository<T_Sys_Role> _repository;
        public RoleService(IRepository<T_Sys_Role> repository)
        {
            _repository = repository;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="whereLambds"></param>
        /// <param name="isSave"></param>
        /// <returns></returns>
        public int DeleteById(Expression<Func<T_Sys_Role, bool>> whereLambds, bool isSave = true)
        {
            return _repository.DeleteById(whereLambds, isSave);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public T_Sys_Role GetModel(Expression<Func<T_Sys_Role, bool>> where)
        {
            return _repository.GetModel(where);
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
        public IEnumerable<T_Sys_Role> GetData(int pageIndex, int pageSize, string key, out int totalItem, bool isAsc = true)
        {
            if (!string.IsNullOrEmpty(key))
            {
                return _repository.GetAllPaged(o => o.F_RoleName.Contains(key), pageIndex, pageSize, out totalItem, o => o.F_Id, isAsc);
            }
            return _repository.GetAllPaged(o => o.F_Id > 0, pageIndex, pageSize, out totalItem, o => o.F_Id, isAsc);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="isSave"></param>
        /// <returns></returns>
        public int Insert(T_Sys_Role entity, bool isSave = true)
        {
            return _repository.Insert(entity, isSave);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="isSave"></param>
        /// <returns></returns>
        public int Update(T_Sys_Role entity, bool isSave = true)
        {
            return _repository.Update(entity, isSave);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T_Sys_Role> GetAll()
        {
            return _repository.GetAll();
        }
    }
}
