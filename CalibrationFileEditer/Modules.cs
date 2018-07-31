using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalibrationFileEditer
{
    class Modules
    {
        List<IModule> ModuleList { get; set; }

        public List<IModule> GetModules()
        {
            var modules = new List<IModule>()
            {
                new GetInfo(),
                new ShowOrders(),
                new RemoveExponentials(),
                new FixTolerances(),
                new FixCodes()
            };
            return modules;
        }
    }
}
