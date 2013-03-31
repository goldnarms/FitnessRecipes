using System.Web;
using AdminPortal.DAL.Models;
using FitnessRecipes.DAL.Models;


namespace AdminPortal.Web.Models
{
    public class AuthenticatedUser
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public Roles.Role Role { get; set; }
    }
}