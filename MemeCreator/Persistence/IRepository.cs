using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using FluentNhibernateBlog.Domain;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Linq;
using ReflectionHelper = FluentNHibernate.Utils.Reflection.ReflectionHelper;

namespace FluentNhibernateBlog.Persistence
{
    public interface IRepository<T> where T : DomainEntity
    {
        void Save(T entity);

        void Update(T entity);

        T Load(Guid id);

        T Get(Guid id);

        T FindBy<U>(System.Linq.Expressions.Expression<Func<T, U>> expression, U search);

        IQueryable<T> Query();

        void Delete(T entity);

        IEnumerable<T> FindAll(params ICriterion[] criteria);

        void Evict(T entity);
        
        IQueryOver<T, T> QueryOver();
    }

    public class Parameter
    {
        public Parameter(string name, object value)
        {
            Name = name;
            Value = value;
        }

        public string Name { get; set; }

        public object Value { get; set; }
    }

    public class NHibernateRepository<T> : IRepository<T> where T : DomainEntity
    {
        private readonly ISession _session;

        public NHibernateRepository(ISession session)
        {
            _session = session;
        }

        #region IRepository Members

        public ISession Session
        {
            get { return _session; }
        }

        public virtual void Save(T entity)
        {
            _session.SaveOrUpdate(entity);
        }

        public virtual void Update(T entity)
        {
            //_session.Merge(entity);
            _session.SaveOrUpdate(entity);
        }

        public virtual T Load(Guid id)
        {
            return _session.Load<T>(id);
        }

        public virtual T Get(Guid id)
        {
            return _session.Get<T>(id);
        }

        public virtual T GetNoCache(Guid id)
        {
            _session.CacheMode = CacheMode.Ignore;
            return _session.Get<T>(id);
        }

        public virtual T Merge(T entity)
        {
            return _session.Merge(entity) as T;
        }

        public virtual IQueryOver<T, T> QueryOver()
        {
            return _session.QueryOver<T>();
        }

        public virtual IQueryable<T> Query()
        {
            return _session.Query<T>() as IQueryable<T>;
        }

        //public virtual IQueryable<T> Query(IDomainQuery<T> whereQuery)
        //{
        //    return Query().Where(whereQuery.Expression);
        //}

        public virtual IQueryable<T> Query(Expression<Func<T, bool>> where)
        {
            return Query().Where(where);
        }

        public virtual void Delete(T entity)
        {
            _session.Delete(entity);
        }

        public virtual void DeleteAll()
        {
            var query = String.Format("from {0}", typeof(T).Name);
            _session.Delete(query);
        }

        public virtual ICriteria CreateCriteria()
        {
            return _session.CreateCriteria(typeof(T));
        }

        public virtual IEnumerable<T> FindAll(params ICriterion[] criteria)
        {
            var crit = _session.CreateCriteria(typeof(T));
            foreach (var criterion in criteria)
            {
                if (criterion == null) continue;
                crit.Add(criterion);
            }
            return crit.Future<T>();
        }

        public virtual T FindBy<TU>(System.Linq.Expressions.Expression<Func<T, TU>> expression, TU search)
        {
            string propertyName = ReflectionHelper.GetAccessor(expression).FieldName;
            ICriteria criteria =
                _session.CreateCriteria(typeof(T)).Add(
                    Restrictions.Eq(propertyName, search));
            return criteria.UniqueResult() as T;
        }

        public virtual ISQLQuery CreateSQLQuery(string sqlQuery)
        {
            return _session.CreateSQLQuery(sqlQuery);
        }

        #endregion

        public static void CreateDbDataParameters(IDbCommand command, Parameter[] parameters)
        {
            foreach (Parameter parameter in parameters)
            {
                IDbDataParameter sp_arg = command.CreateParameter();
                sp_arg.ParameterName = parameter.Name;
                sp_arg.Value = parameter.Value;
                command.Parameters.Add(sp_arg);
            }
        }



        public virtual void Evict(T entity)
        {
            _session.Evict(entity);
        }

        public void Flush()
        {
            _session.Flush();
        }
    }

    //public class PublishingRepository<T> : NHibernateRepository<T> where T : DomainEntity
    //{
    //    private readonly IValueObjectRegistry _valueObjectRegistry;

    //    public PublishingRepository(ISession session, IValueObjectRegistry valueObjectRegistry)
    //        : base(session)
    //    {
    //        _valueObjectRegistry = valueObjectRegistry;
    //    }

    //    public override void Update(T entity)
    //    {
    //        base.Update(entity);

    //        if (entity.IsActive)
    //            _valueObjectRegistry.Add(entity);
    //        else
    //            _valueObjectRegistry.Remove(entity);

    //    }

    //    public override void Save(T entity)
    //    {
    //        base.Save(entity);

    //        if (entity.IsActive)
    //            _valueObjectRegistry.Add(entity);
    //        else
    //            _valueObjectRegistry.Remove(entity);
    //    }

    //    public override void Delete(T entity)
    //    {
    //        base.Delete(entity);
    //        _valueObjectRegistry.Remove(entity);
    //    }
    //}
}