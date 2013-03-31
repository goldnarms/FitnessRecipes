using WatiN.Core;

namespace FitnessRecipes.WebTests.Helpers
{
    public static class WatinExtensions
    {
        public static void ForceChange(this Element e)
        {
            e.DomContainer.Eval("$('#" + e.Id + "').change();");
        }
    }
}
