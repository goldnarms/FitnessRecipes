//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FitnessRecipes.DAL.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Comment
    {
        public Comment()
        {
            this.Comment1 = new HashSet<Comment>();
        }
    
        public int Id { get; set; }
        public string Text { get; set; }
        public System.DateTime DateAdded { get; set; }
        public bool IsDeleted { get; set; }
        public Nullable<int> UserId { get; set; }
        public string Username { get; set; }
        public Nullable<int> CommentId { get; set; }
        public string Email { get; set; }
        public string WebSite { get; set; }
    
        public virtual User User { get; set; }
        public virtual ICollection<Comment> Comment1 { get; set; }
        public virtual Comment Comment2 { get; set; }
        public virtual Diet Diet { get; set; }
        public virtual Meal Meal { get; set; }
    }
}
