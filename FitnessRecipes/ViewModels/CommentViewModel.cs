using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using FitnessRecipes.DAL.Models;
using Comment = FitnessRecipes.Resources.Models.CommentModel;


namespace FitnessRecipes.ViewModels
{
    public class CommentViewModel
    {
        public int Id { get; set; }
        public string Header { get; set; }
        [Display(ResourceType = typeof(Comment), Name = "Comment", Prompt = "CommentPlaceholder")]
        public string Text { get; set; }
        public DateTime DateAdded { get; set; }
        public bool IsDeleted { get; set; }
        [Display(ResourceType = typeof(Comment), Name = "Username", Prompt = "UsernamePlaceholder")]
        public string Username { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<CommentViewModel> SubComments { get; set; }
        public int? CommentId { get; set; }
        [Display(ResourceType = typeof(Comment), Name = "Email", Prompt = "EmailPlaceholder")]
        public string Email { get; set; }
        [Display(ResourceType = typeof(Comment), Name = "Website", Prompt = "WebsitePlaceholder")]
        public string WebSite { get; set; }
    }
}