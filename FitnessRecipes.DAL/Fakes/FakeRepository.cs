using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using FitnessRecipes.DAL.Interfaces;
using FitnessRecipes.DAL.Models;

namespace FitnessRecipes.DAL.Fakes
{
    public abstract class FakeRepository<T> : IRepository<T>
        where T : class
    {
        protected FakeRepository()
        {
            _dictionary = new Dictionary<int, T>();
        }

        protected Dictionary<int, T> _dictionary;
        public T Get(int id)
        {
            if (_dictionary.ContainsKey(id))
                return _dictionary[id];
            return null;
        }

        public IEnumerable<T> GetAll()
        {
            return _dictionary.Values;
        }

        public IEnumerable<T> Query(Expression<Func<T, bool>> filter)
        {
            return _dictionary.Values.AsQueryable().Where(filter);
        }

        public void Add(T entity)
        {
            _dictionary.Add(_dictionary.Count, entity);
        }

        public int Remove(T entity)
        {
            if (_dictionary.ContainsValue(entity))
                _dictionary.Remove(_dictionary.Single(ent => ent.Value == entity).Key);
            return 0;
        }

        public int Update(int id, T entity)
        {
            if (_dictionary.ContainsKey(id))
                _dictionary[id] = entity;
            return id;
        }

        public bool Contains(int id)
        {
            return _dictionary.ContainsKey(id);
        }

        public IEnumerable<T> Filter(Expression<Func<T, bool>> predicate)
        {
            return _dictionary.Values.AsQueryable().Where(predicate);
        }

        public IEnumerable<T> Filter<Key>(Expression<Func<T, bool>> filter, out int total, int index = 0, int size = 50)
        {
            throw new NotImplementedException();
        }

        public bool Contains(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public T Find(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public T Create(T obj)
        {
            dynamic dynObj = obj;
            _dictionary.Add(_dictionary.Count +1, obj);
            if (dynObj.PropertyExist("Id"))
                dynObj.Id = _dictionary.Count;
            return dynObj;
        }

        public int Update(T obj)
        {
            throw new NotImplementedException();
        }

        public int Count { get; private set; }
        public void RemoveIngredientFromDiet(int dietId, int ingredientId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Recipe> GetMatching(List<int> liste)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Ingredient> GetIngredientsForRecipe(int id)
        {
            throw new NotImplementedException();
        }
    }
}
