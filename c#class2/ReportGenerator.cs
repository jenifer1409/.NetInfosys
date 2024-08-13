using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_class2
{
    public class ReportGenerator : IReportGenerator
    {
        public string GenerateReport(Vehicle v)
        {
            return $"vehicle details {v.Id} , {v.Make} ,{v.Model},{v.Year}";
        }
    }
}
