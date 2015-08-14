using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Text;
using System.Threading.Tasks;
using RadarChart.Infrastructure.Persistence.EF;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq.Expressions;

namespace RadarChart.Core.Repository
{
    public class RadarChartRepositoryBase<T> where T : class,new()
    {
        protected RadarChartDataContext db;
        protected readonly DbSet<T> dbset;
        public UnitOfWork unitOfWork;

        public RadarChartRepositoryBase()
        {
            this.unitOfWork = new UnitOfWork();
            db = new RadarChartDataContext();
            dbset = db.Set<T>();
        }

        public RadarChartRepositoryBase(UnitOfWork unit)
        {
            this.unitOfWork = unit;
            db = this.unitOfWork.GetDBContext();
            dbset = db.Set<T>();
        }

        /// <summary>
        /// get one entity
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public T GetOne(Expression<Func<T, bool>> expression)
        {

            var entity = dbset.FirstOrDefault(expression);
            return entity;


        }

        /// <summary>
        /// Add one entity
        /// </summary>
        /// <param name="entity"></param>
        public void Add(T entity)
        {
            dbset.Add(entity);
            unitOfWork.Commit();
        }
        /// <summary>
        /// Add one entity
        /// </summary>
        /// <param name="entity"></param>
        public void AddState(T entity)
        {
            dbset.Add(entity);
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="expression"></param>
        public void Delete(T entity)
        {
            var entry = db.Entry(entity);
            dbset.Attach(entity);
            entry.State = EntityState.Deleted;
            unitOfWork.Commit();
        }

        public void Delete(Expression<Func<T, bool>> expression)
        {
            IEnumerable<T> objects = dbset.Where<T>(expression).AsEnumerable();
            dbset.RemoveRange(objects);
            unitOfWork.Commit();
        }

        public void DeleteState(Expression<Func<T, bool>> expression)
        {
            IEnumerable<T> objects = dbset.Where<T>(expression).AsEnumerable();
            dbset.RemoveRange(objects);
        }

        /// <summary>
        /// Update depends on Key
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Modify(T entity)
        {
            var entry = db.Entry(entity);
            dbset.Attach(entity);
            entry.State = EntityState.Modified;
            unitOfWork.Commit();
        }
        public void ModifyState(T entity)
        {
            var entry = db.Entry(entity);
            dbset.Attach(entity);
            entry.State = EntityState.Modified;
        }

        /// <summary>
        /// Get
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public T Get(Expression<Func<T, bool>> expression)
        {
            var model = dbset.FirstOrDefault(expression);
            return model;
        }
        public T Get(string QueryWhere)
        {
            var query = dbset.Where(QueryWhere).FirstOrDefault();
            return query;
        }

        /// <summary>
        /// Get List
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public IQueryable<T> GetList(Expression<Func<T, bool>> expression)
        {
            var list = dbset.Where(expression);
            return list;
        }
        public List<T> GetList(string QueryWhere)
        {
            var query = dbset.Where(QueryWhere);
            return query.ToList();
        }
        public List<T> GetList<S>(Expression<Func<T, bool>> expression, Expression<Func<T, S>> orderByExpression, bool IsDESC)
        {
            var query = dbset.Where(expression);
            query = IsDESC ? query.OrderByDescending(orderByExpression) : query.OrderBy(orderByExpression);
            return query.ToList();
        }
        public List<T> GetList<S>(string queryWhere, Expression<Func<T, S>> orderByExpression, bool IsDESC)
        {
            var query = dbset.Where(queryWhere);
            query = IsDESC ? query.OrderByDescending(orderByExpression) : query.OrderBy(orderByExpression);
            return query.ToList();
        }
        public IQueryable<T> GetList(string SearchCondition, string OrderExpression)
        {
            var query = dbset.Where(SearchCondition).OrderBy(OrderExpression);
            return query;
        }

        /// <summary>
        /// Execute Sql
        /// </summary>
        /// <param name="strsql">sql expression</param>
        /// <returns></returns>
        public List<T> GetList(string strsql, SqlParameter[] parms)
        {
            var DataList = this.db.Database.SqlQuery<T>(strsql, parms).ToList();
            return DataList;
        }

        /// <summary>
        /// Get data by expression
        /// </summary>
        /// <typeparam name="S"></typeparam>
        /// <param name="TopN">data</param>
        /// <param name="condition">Lambda expression</param>
        /// <param name="orderByExpression">Lambda expression</param>
        /// <param name="IsDESC"></param>
        /// <returns></returns>
        public List<T> GetTopList(int TopCount)
        {
            var query = dbset.Take(TopCount);
            return query.ToList();
        }
        public List<T> GetTopList(int TopCount, string queryWhere)
        {
            var query = dbset.Where(queryWhere).Take(TopCount);
            return query.ToList();
        }
        public List<T> GetTopList<S>(int TopCount, Expression<Func<T, bool>> expression, Expression<Func<T, S>> orderByExpression, bool IsDESC)
        {
            var query = dbset.Where(expression);
            query = IsDESC ? query.OrderByDescending(orderByExpression) : query.OrderBy(orderByExpression);
            query.Take(TopCount);
            return query.ToList();
        }
        public List<T> GetTopList<S>(int TopCount, string queryWhere, Expression<Func<T, S>> orderByExpression, bool IsDESC)
        {
            var query = dbset.Where(queryWhere);
            query = IsDESC ? query.OrderByDescending(orderByExpression) : query.OrderBy(orderByExpression);
            query.Take(TopCount);
            return query.ToList();
        }

        /// <summary>
        /// Get all
        /// </summary>
        /// <returns></returns>
        public List<T> GetAll()
        {
            return dbset.ToList();
        }

        /// <summary>
        /// Execute sql statement（add、update、delete）
        /// </summary>
        /// <param name="strsql">sql statements</param>
        /// <returns></returns>
        public void SqlCommand(string strsql)
        {
            this.db.Database.ExecuteSqlCommand(strsql);
        }

        /// <summary>
        /// Execute SP
        /// </summary>
        /// <param name="storedProcName">SP name</param>
        /// <param name="parameters">SP params</param>
        /// <param name="parametersvalues">sp Parame Values</param>
        /// <returns></returns>
        public List<T> RunProcedure(string storedProcName, string[] parameters, string[] parametersvalues)
        {
            string sqlpar = "";
            List<T> list = new List<T>();
            SqlParameter[] selparms = new SqlParameter[parameters.Length];
            for (int i = 0; i < parameters.Length; i++)
            {
                selparms[i] = new SqlParameter("@" + parameters[i], parametersvalues[i]);
                sqlpar += "@" + parameters[i] + ",";
            }
            sqlpar = sqlpar.Substring(0, sqlpar.Length - 1);
            list = this.db.Database.SqlQuery<T>("exec " + storedProcName + " " + sqlpar, selparms).ToList();
            return list;
        }

        public void SaveChanges()
        {
            unitOfWork.Commit();
        }


    }
}
