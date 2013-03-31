using System.Linq;
using FitnessRecipes.Controllers.Api;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FitnessRecipes.Tests.ApiControllers
{
    [TestClass]
    public class CategoryControllerTest
    {
        [TestMethod]
        public void GetCategories()
        {
            var controller = new CategoryController();
            var categories = controller.GetCategories();
            Assert.IsNotNull(categories);
            Assert.IsTrue(categories.Any());
        }

        [TestMethod]
        public void GetCategory()
        {
            var controller = new CategoryController();
            var id = 1;
            var category = controller.GetCategory(id);
            Assert.IsNotNull(category);
            Assert.AreEqual(category.Id, id);
        }
    }
}
