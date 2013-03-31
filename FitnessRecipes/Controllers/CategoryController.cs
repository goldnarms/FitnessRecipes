using System.Web.Mvc;
using FitnessRecipes.ViewModels;

namespace FitnessRecipes.Controllers
{
    public class CategoryController : Controller
    {
        private readonly Api.CategoryController _categoryController;

        public CategoryController()
        {
            _categoryController = new Api.CategoryController();
        }
        public ActionResult Index()
        {
            return View(_categoryController.GetCategories());
        }

        //
        // GET: /Category/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Category/Create

        public ActionResult Create()
        {
            return View(new MealCategoryViewModel());
        }

        //
        // POST: /Category/Create

        [HttpPost]
        public ActionResult Create(MealCategoryViewModel mealCategoryViewModel)
        {
            try
            {
                _categoryController.PostCategory(mealCategoryViewModel);
                return View("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Category/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Category/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            try
            {
                _categoryController.DeleteCategory(id);
            }
            catch
            {
            }
            return View("Index");
        }
    }
}
