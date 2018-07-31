using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalibrationFileEditer
{
    interface IModule
    {
        string GetName();
        void RunProgram(DataProvider data);
    }
}
