using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NIR4CalibrationEditorMethods.Modules;

namespace ConsoleCalibrationFileEditer
{
    internal class Display
    {
        internal void DisplayMethods(List<IModule> modules)
        {
            for(var i = 0; i < modules.Count; i++)
            {
                Console.WriteLine($"{i+1}: {modules[i].Name}");
            }
        }
    }
}
