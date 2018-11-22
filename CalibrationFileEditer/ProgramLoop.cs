using log4net;
using NIR4CalibrationEditorMethods.FileManager;
using NIR4CalibrationEditorMethods.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCalibrationFileEditer
{
    class ProgramLoop
    {
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private readonly DataProvider data;

        public ProgramLoop(DataProvider data)
        {
            this.data = data;
        }

        internal void Run(List<IModule> modules)
        {
            Display display = new Display();
            display.DisplayMethods(modules);
            bool complete = false;
            while (!complete)
            {
                string input = Console.ReadLine();
                Log.Debug($"Console input = {input}");
                try
                {
                    if (input.ToLower() == "q")
                    {
                        complete = true;
                        break;
                    }
                    int choice = int.Parse(input);
                    if (choice < 1 || choice > modules.Count)
                    {
                        Log.Error($"Incorrect input. User input was outside of module choice range. ({input})");
                    }
                    else
                    {
                        modules[choice - 1].Run(data);
                    }
                }
                catch
                {
                    Log.Error($"Unable to parse user input - {input}");
                }
            }
        }
    }
}
