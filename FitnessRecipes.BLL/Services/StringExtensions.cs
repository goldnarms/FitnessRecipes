using System;
using System.Linq;

namespace FitnessRecipes.BLL.Services
{
    public static class StringExtensions
    {
        public static int[] ToIntArray(this string csv)
        {
            var array = csv.Split(',');
            var days = new int[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                days[i] = Convert.ToInt16(array[i]);
            }
            return days;
        }

        public static string Shorten(this string text, int length = 25)
        {
            if (text.Length > length)
                return text.Substring(0, length) + " ...";
            return text;
        }

        public static int Max(this string csv)
        {
            var array = csv.Split(',');
            var days = new int[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                days[i] = Convert.ToInt16(array[i]);
            }
            return days.Concat(new[] {0}).Max();
        }
    }
}
