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
    class BusinessService : IBusinessService
    {
        private readonly IRepository<T_Sys_Business> _repository;
        public BusinessService(IRepository<T_Sys_Business> repository)
        {
            _repository = repository;
        }
        public int DeleteById(Expression<Func<T_Sys_Business, bool>> whereLambds, bool isSave = true)
        {
            return _repository.DeleteById(whereLambds, isSave);
        }

        public IEnumerable<T_Sys_Business> GetData(int pageIndex, int pageSize, string key, out int totalItem, bool isAsc = true)
        {
            if (!string.IsNullOrEmpty(key))
            {
                return _repository.GetAllPaged(o => o.F_BusinessName.Contains(key), pageIndex, pageSize, out totalItem, o => o.F_Id, isAsc);
            }
            return _repository.GetAllPaged(o => o.F_Id > 0, pageIndex, pageSize, out totalItem, o => o.F_Id, isAsc);
        }

        public T_Sys_Business GetModel(Expression<Func<T_Sys_Business, bool>> where)
        {
            return _repository.GetModel(where);
        }

        public int Insert(T_Sys_Business entity, bool isSave = true)
        {
            return _repository.Insert(entity, isSave);
        }

        public int Update(T_Sys_Business entity, bool isSave = true)
        {
            return _repository.Update(entity, isSave);
        }
    }
}
