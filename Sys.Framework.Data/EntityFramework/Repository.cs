using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Sys.Framework.Data.EntityFramework
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        Context _dbContext = new Context();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="isSave"></param>
        /// <returns></returns>
        public int Insert(TEntity entity, bool isSave = true)
        {
            if (entity == null) { throw new ArgumentNullException("entity"); }
            if (isSave)
            {
                _dbContext.Entry<TEntity>(entity).State = EntityState.Added;
                return _dbContext.SaveChanges();
            }
            return 0;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="whereLambds"></param>
        /// <param name="isSave"></param>
        /// <returns></returns>
        public int DeleteById(Expression<Func<TEntity, bool>> whereLambds, bool isSave = true)
        {
            if (whereLambds == null) { throw new ArgumentNullException("entity"); }
            if (isSave)
            {
                List<TEntity> listDeleting = _dbContext.Set<TEntity>().Where(whereLambds).ToList();
                listDeleting.ForEach(u =>
                {
                    _dbContext.Set<TEntity>().Attach(u);
                    _dbContext.Set<TEntity>().Remove(u);
                });
                return _dbContext.SaveChanges();
            }
            return 0;
        }
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
        public IEnumerable<TEntity> GetAllPaged<S>(Expression<Func<TEntity, bool>> whereLambds, int pageIndex, int pageSize, out int totalItem, System.Linq.Expressions.Expression<Func<TEntity, S>> orderByLambds, bool isAsc = true)
        {

            var query = _dbContext.Set<TEntity>().Where<TEntity>(whereLambds).OrderBy(orderByLambds).AsNoTracking() as IQueryable<TEntity>;
            totalItem = query.Count();
            int skip = (pageIndex - 1) * pageSize;
            int take = pageSize;
            query = isAsc ? query.OrderBy<TEntity, S>(orderByLambds) : query.OrderByDescending<TEntity, S>(orderByLambds);
            query = query.Skip<TEntity>(skip).Take<TEntity>(take);
            return query;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="isSave"></param>
        /// <returns></returns>
        public int Update(TEntity entity, bool isSave = true)
        {
            if (entity == null) { throw new ArgumentNullException("entity"); }
            if (isSave)
            {
                RemoveHoldingEntityInContext(entity);
                _dbContext.Entry<TEntity>(entity).State = EntityState.Modified;
                return _dbContext.SaveChanges();
            }
            return 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public TEntity GetModel(Expression<Func<TEntity, bool>> where)
        {
            return _dbContext.Set<TEntity>().Where<TEntity>(where).AsNoTracking().FirstOrDefault();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public IEnumerable<TEntity> SqlQuery(string sql, params object[] parameters)
        {
            return _dbContext.Set<TEntity>().SqlQuery(sql, parameters).AsNoTracking();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>

        public IEnumerable<TEntity> GetAll()
        {
            return _dbContext.Set<TEntity>().AsNoTracking().ToList();
        }
        /// <summary>
        /// 原因是在Context中还保留有当前实体的副本所致，这里只要我们将实体副本从内存中完全移除，就可以了。
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        private Boolean RemoveHoldingEntityInContext(TEntity entity)
        {
            var objContext = ((IObjectContextAdapter)_dbContext).ObjectContext;
            var objSet = objContext.CreateObjectSet<TEntity>();
            var entityKey = objContext.CreateEntityKey(objSet.EntitySet.Name, entity);

            Object foundEntity;
            var exists = objContext.TryGetObjectByKey(entityKey, out foundEntity);

            if (exists)
            {
                objContext.Detach(foundEntity);
            }

            return (exists);
        }
    }
}
