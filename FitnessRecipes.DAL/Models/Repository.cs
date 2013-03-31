using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using FitnessRecipes.DAL.Interfaces;

namespace FitnessRecipes.DAL.Models
{
    public abstract class Repository<T> : IRepository<T>
        where T : class
    {
        protected FitnessRecipiesEntities Context;

        private readonly bool _shareContext = false;

        protected Repository(FitnessRecipiesEntities context)
        {
            Context = context;
            _shareContext = true;
        }

        protected Repository()
        {
            Context = new FitnessRecipiesEntities();
        }

        protected DbSet<T> DbSet
        {
            get
            {
                return Context.Set<T>();
            }
        }

        public void Dispose()
        {
            if (_shareContext && (Context != null))
                Context.Dispose();
        }

        public abstract T Get(int id);

        public abstract IEnumerable<T> GetAll();

        public IEnumerable<T> Query(Expression<Func<T, bool>> filter)
        {
            return DbSet.Where(filter);
        }

        public void Add(T entity)
        {
            DbSet.Add(entity);
            //if (!_shareContext)
                Context.SaveChanges();
        }

        public virtual int Count
        {
            get
            {
                return DbSet.Count();
            }
        }

        public void RemoveIngredientFromDiet(int dietId, int ingredientId)
        {
            throw new NotImplementedException();
        }

        public virtual int Remove(T entity)
        {
            DbSet.Remove(entity);
            //return !_shareContext ? Context.SaveChanges() : 0;
            return Context.SaveChanges();
        }

        public IEnumerable<T> Filter<Key>(Expression<Func<T, bool>> filter, out int total, int index = 0, int size = 50)
        {
            var result = DbSet.AsQueryable().Where(filter).Skip(index).Take(50);
            total = result.Count();
            return result;
        }

        public int Update(int id, T entity)
        {
            var entry = Context.Entry(entity);
            DbSet.Attach(entity);
            entry.State = EntityState.Modified;
            return !_shareContext ? Context.SaveChanges() : 0;
        }

        public IEnumerable<T> Filter(Expression<Func<T, bool>> predicate)
        {
            return DbSet.AsQueryable().Where(predicate);
        }

        public bool Contains(Expression<Func<T, bool>> predicate)
        {
            return DbSet.AsQueryable().Where(predicate).Any();
        }


        public T Find(Expression<Func<T, bool>> predicate)
        {
            return DbSet.AsQueryable().FirstOrDefault(predicate);
        }

        public T Create(T t)
        {
            DbSet.Add(t);
            Context.GetValidationErrors();
            Context.SaveChanges();
            return t;
        }

        public void Delete(T t)
        {
            DbSet.Remove(t);
            Context.SaveChanges();
        }

        public int Delete(Expression<Func<T, bool>> predicate)
        {
            foreach (var obj in DbSet.AsQueryable().Where(predicate))
            {
                DbSet.Remove(obj);
            }
            Context.SaveChanges();
            return 0;
        }

        public int Update(T t)
        {
            var entry = Context.Entry(t);
            DbSet.Attach(t);
            entry.State = EntityState.Modified;
            return Context.SaveChanges();
        }
    }
}