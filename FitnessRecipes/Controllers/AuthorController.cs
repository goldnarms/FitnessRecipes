using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using FitnessRecipes.DAL.Models;
using FitnessRecipes.Models;
using FitnessRecipes.ViewModels;

namespace FitnessRecipes.Controllers
{
    public class AuthorController : BaseController
    {
        private readonly Api.AuthorController _authorController;

        public AuthorController()
        {
            _authorController = new Api.AuthorController();
        }

        public AuthorController(Api.AuthorController authorController)
        {
            _authorController = authorController;
        }

        public ActionResult Index()
        {
            var bloggere = _authorController.GetAuthors().ToList();
            const string alfabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZÆØÅ";
            var alfabetDic = alfabet.ToDictionary(t => t, t => bloggere.Where(blogger => blogger.User.Name.ToUpper()[0] == t).ToList());
            return View(alfabetDic);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new AuthorViewModel());
        }

        [HttpPost]
        public ActionResult Create(AuthorViewModel viewModel)
        {
            _authorController.PostAuthor(viewModel);
            return View();
        }

        public ActionResult Edit(int id)
        {
            return View(_authorController.GetAuthor(id));
        }

        [HttpPost]
        public ActionResult Edit(int id, AuthorViewModel viewModel)
        {
            try
            {
                _authorController.PutAuthor(id, viewModel);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Author(int id)
        {
            return View(Mapper.Map<Author, AuthorViewModel>(_authorController.GetAuthor(id)));
        }
    }
}
