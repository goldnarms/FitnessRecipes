using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FitnessRecipes.DAL.Models;

namespace FitnessRecipes.ViewModels
{
    public class CommentViewModel
    {
        public int Id { get; set; }
        public string Header { get; set; }
        public string Text { get; set; }
        public DateTime DateAdded { get; set; }
        public bool IsDeleted { get; set; }
        public string Username { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<CommentViewModel> SubComments { get; set; }
        public int? CommentId { get; set; }
        public string Email { get; set; }
        public string WebSite { get; set; }
    }
}