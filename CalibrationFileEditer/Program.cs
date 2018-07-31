using CalibrationFileEditer.Programs;
using System;
using System.Collections.Generic;
using System.IO;

namespace CalibrationFileEditer
{
    class Program
    {
        static void Main(string[] args)
        {
            if (!File.Exists(args[0]))
            {
                Console.WriteLine("Drag file onto icon!");
                Console.ReadLine();
                return;
            }

            Console.WriteLine($"Editting: '{Path.GetFileName(args[0])}'");
            Console.WriteLine();

            var provider = new DataProvider(File.ReadAllText(args[0]));
            var parameters = new CreateNIR4ParameterList().GetParameters(provider);
            var modules = new Modules().GetModules();
            var display = new ConsoleDisplay(modules);
            bool completed = false;
            display.DisplayModules();
            while (!completed)
            {
                Console.Write("Choose a program: ");
                var input = Console.ReadLine();
                Console.Clear();
                display.DisplayModules();

                if (input.ToLower().StartsWith("q"))
                {
                    completed = true;
                }
                else
                {
                    try
                    {
                        var method = int.Parse(input);
                        modules[method - 1].RunProgram(provider);
                        Console.WriteLine();
                    }
                    catch
                    {
                        Console.WriteLine("Invalid selection.");
                        Console.WriteLine();
                    }
                }               
            }

            var filePath = Path.GetFullPath(args[0]);
            var fileName = Path.GetFileNameWithoutExtension(args[0]);
            var newFileName = filePath.Replace(fileName, $"{fileName}_converted");
            File.WriteAllText(newFileName, provider.GetData());
            Console.WriteLine($"File saved: {newFileName}");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

       
    }
}
