using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using FitnessRecipes.DAL.Models;

namespace FitnessRecipes.DAL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        T Get(int id);
        IEnumerable<T> GetAll();
        IEnumerable<T> Query(Expression<Func<T, bool>> filter);
        void Add(T entity);
        int Remove(T entity);
        int Update(int id, T entity);
        IEnumerable<T> Filter(Expression<Func<T, bool>> predicate);
        IEnumerable<T> Filter<Key>(Expression<Func<T, bool>> filter, out int total, int index = 0, int size = 50);
        bool Contains(Expression<Func<T, bool>> predicate);
        T Find(Expression<Func<T, bool>> predicate);
        T Create(T obj);
        int Update(T obj);
        int Count { get; }
    }
}
