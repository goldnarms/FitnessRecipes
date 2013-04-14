using System;
using FitnessRecipes.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Should;

namespace FitnessRecipes.Tests.Helpers
{
    [TestClass]
    public class FacebookTest
    {
        [TestMethod]
        public void ShouldGetInfoAboutMe()
        {
            var facebookHelper = new FacebookHelper();
            facebookHelper.ShareOnFacebook().ShouldEqual("fee");
        }
    }
}
