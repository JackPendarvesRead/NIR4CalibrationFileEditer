using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalibrationFileEditer
{
    class ConsoleDisplay
    {
        private List<IModule> Modules { get; set; }

        public ConsoleDisplay(List<IModule> modules)
        {
            Modules = modules;
        }

        public void DisplayModules()
        {
            for (var i = 0; i < Modules.Count; i++)
            {
                Console.WriteLine($"{ i + 1}: {Modules[i].GetName()}");
            }
            Console.WriteLine("Q: Save and Exit");
            Console.WriteLine();
            Console.Write("Choose a program: ");
        }
    }
}
