using FitnessRecipes.DAL.Fakes;
using FitnessRecipes.DAL.Interfaces;
using FitnessRecipes.DAL.Models;
using FitnessRecipes.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;

namespace FitnessRecipes.Tests.Models
{
    [TestClass]
    public class AuthorTest
    {
        public static IKernel _kernel;
        private Author _aksjon;
        private static IRepository<Author> _repository;

        [ClassInitialize]
        public static void ClassBuildUp(TestContext kontekst)
        {
            _kernel = new StandardKernel();
            _kernel.Bind(typeof(IRepository<>)).To(typeof(FakeRepository<>));
            _repository = _kernel.Get<IRepository<Author>>();
        }
    }
}
