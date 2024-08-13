using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_class2
{

    //open - close principle 
    public interface IReportGenerator
    {
        string GenerateReport(Vehicle v);

    }
}
