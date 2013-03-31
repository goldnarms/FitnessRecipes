using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitnessRecipes.Helpers
{
    public static class IntExtensions
    {
        public static string ToTimeString(this int minutes)
        {
            var hours = minutes/60;
            var minute = minutes%60;
            return string.Format("{0}:{1}", hours, minute.ToString("D2"));
        }

        public static DateTime ToDateTime(this int minutes)
        {
            var hours = minutes / 60;
            var minute = minutes % 60;
            var min = DateTime.MinValue;
            return min.AddHours(hours).AddMinutes(minute);
        }
    }
}