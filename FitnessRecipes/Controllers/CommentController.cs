using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FitnessRecipes.DAL.Models;
using FitnessRecipes.ViewModels;

namespace FitnessRecipes.Controllers
{
    public class CommentController : Controller
    {
        [HttpGet]
        public PartialViewResult LeaveComment()
        {
            return PartialView("_LeaveComment", new CommentViewModel());
        }

        [HttpPost]
        public ActionResult LeaveComment(User user, string comment, int commentId)
        {
            return View();
        }
    }
}
