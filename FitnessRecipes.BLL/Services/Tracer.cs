using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitnessRecipes.BLL.Interfaces;

namespace FitnessRecipes.BLL.Services
{
    public class Tracer : ITracer
    {
        public void WriteTrace(string mesage)
        {
            System.Diagnostics.Trace.TraceInformation(mesage);
        }
    }
}
