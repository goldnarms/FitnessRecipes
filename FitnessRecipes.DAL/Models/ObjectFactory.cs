using System;
using FitnessRecipes.DAL.Interfaces;

namespace FitnessRecipes.DAL.Models
{
    public class ObjectFactory
    {
        //public static TRepository GetRepositoryInstance<T, TRepository>()
        //  where TRepository : IRepository<T>, new() where T : class
        //{
        //    return new TRepository();
        //}
        public static TRepository GetRepositoryInstance<T, TRepository>(params object[] args)  where TRepository : IRepository<T> where T : class
        {
            return (TRepository)Activator.CreateInstance(typeof(TRepository), args);
        }

    }
}