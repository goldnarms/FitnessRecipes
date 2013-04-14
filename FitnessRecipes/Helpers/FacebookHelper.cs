using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Facebook;

namespace FitnessRecipes.Helpers
{
    public class FacebookHelper
    {
        public string ShareOnFacebook()
        {

            var accessToken = "BAACOtgt7Ij0BAL9ew2NvZAp3PUM111hAN8hKgn78mHa1Ig6IVSEkuQ1scxluGX6AegGLEYaBz1tQ6SNfC453IIhRFSnjzmddRFxddllF8cCbYZBxXp1UzhMU9jeqE2RIhfqPVepb8P6rZAywYVvdHaGsJSLmXSwXuU58ZCyjvozUgVZAyZCFL2hEu44ZBWvY8XETQkFEDW2LAZDZD";
            var client = new FacebookClient(accessToken);
            dynamic me = client.Get("me");
            return me.about;
        }
    }
}