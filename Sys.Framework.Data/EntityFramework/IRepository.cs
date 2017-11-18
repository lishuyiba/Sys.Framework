using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Sys.Framework.Data.EntityFramework
{
    public interface IRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// 添加一条记录
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="isSave"></param>
        /// <returns></returns>
        int Insert(TEntity entity, bool isSave = true);
        /// <summary>
        /// 获取一条记录
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        TEntity GetModel(Expression<Func<TEntity, bool>> where);
        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="id"></param>
        /// <param name="isSave"></param>
        /// <returns></returns>
        int DeleteById(Expression<Func<TEntity, bool>> whereLambds, bool isSave = true);
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
        IEnumerable<TEntity> GetAllPaged<S>(Expression<Func<TEntity, bool>> whereLambds, int pageIndex, int pageSize, out int totalItem, Expression<Func<TEntity, S>> orderByLambds, bool isAsc = true);
        /// <summary>
        /// 更新一个实体
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="isSave"></param>
        /// <returns></returns>
        int Update(TEntity entity, bool isSave = true);

        /// <summary>
        /// 执行SQL
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        IEnumerable<TEntity> SqlQuery(string sql, params object[] parameters);
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>

        IEnumerable<TEntity> GetAll();
    }
}
