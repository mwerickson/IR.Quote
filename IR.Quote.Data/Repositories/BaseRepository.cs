using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using IR.Quote.Data.Connection;

namespace IR.Quote.Data.Repositories
{
    public class BaseRepository<T> where T : class, new()
    {
        protected IDbConnectionFactory DbFactory { get; private set; }

        public BaseRepository(IDbConnectionFactory db)
        {
            this.DbFactory = db;
        }

        protected T From(Expression<Func<T, bool>> predicate)
        {
            using (var cxn = DbFactory.OpenDbConnection())
            {
                try
                {
                    return cxn.Get<T>(predicate);
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

        protected List<T> Where(Expression<Func<T, bool>> predicate)
        {
            using (var cxn = DbFactory.OpenDbConnection())
            {
                return cxn.Table<T>().Where(predicate).ToList();
            }
        }

        public virtual List<T> All()
        {
            using (var cxn = DbFactory.OpenDbConnection())
            {
                return cxn.Table<T>().ToList();
            }
        }

        public virtual T Save(T model)
        {
            using (var cxn = DbFactory.OpenDbConnection())
            {
                var saved = cxn.Update(model);   // Id is populated on an insert
                return model;
            }
        }

        public virtual long Insert(T model)
        {
            using (var cxn = DbFactory.OpenDbConnection())
            {
                return cxn.Insert(model);
            }
        }

        public virtual void Delete(T model)
        {
            using (var cxn = DbFactory.OpenDbConnection())
            {
                var x = cxn.Delete(model);
            }
        }

        protected virtual void OnUpdate(T model) { }
    }
}