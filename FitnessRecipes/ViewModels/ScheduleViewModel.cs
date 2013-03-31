using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitnessRecipes.ViewModels
{
    public class ScheduleViewModel
    {
        public int Day { get; set; }
        public int Time { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }
    }
}