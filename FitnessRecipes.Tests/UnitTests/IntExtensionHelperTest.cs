using System;
using FitnessRecipes.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Should;

namespace FitnessRecipes.Tests.UnitTests
{
    [TestClass]
    public class IntExtensionHelperTest
    {
        [TestMethod]
        public void ToTimeStringShouldConvertMinutesToHourAndMinutes()
        {
            const int minutes = 545;
            minutes.ToTimeString().ShouldEqual("9:05");
        }

        [TestMethod]
        public void ToTimeShouldConvertMinutesToDateTime()
        {
            const int minutes = 545;
            var dateTime = DateTime.MinValue.AddHours(9).AddMinutes(5);
            minutes.ToDateTime().ShouldEqual(dateTime);
            minutes.ToDateTime().ShouldEqual(dateTime);
        }
    }
}
