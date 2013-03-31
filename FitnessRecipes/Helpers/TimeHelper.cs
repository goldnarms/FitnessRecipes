using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FitnessRecipes.Controllers;

namespace FitnessRecipes.Helpers
{
    public class TimeHelper
    {
        public static List<Time> GetTimesForDay()
        {
            var list = new List<Time>();
            for (int i = 0; i <= 1410; i = i + 30)
            {
                list.Add(new Time(i));
            }
            return list;
        }
    }
}