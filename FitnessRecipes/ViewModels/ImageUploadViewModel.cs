using System.Web;

namespace FitnessRecipes.ViewModels
{
    public class ImageUploadViewModel
    {
        public string ImageSource { get; set; }
        public bool HideUploadDiv { get; set; }
        public HttpPostedFileWrapper File { get; set; }
    }
}