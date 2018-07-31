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
            //example parameter line = <parameter tolerance="2.5" label="Dry Matter" unit=" % " order="0">DM</parameter>
            if (!File.Exists(args[0]))
            {
                Console.WriteLine("Drag file onto icon!");
                Console.ReadLine();
                return;
            }

            Console.WriteLine($"Editting: '{Path.GetFileName(args[0])}'");
            Console.WriteLine();
            var readFile = File.ReadAllText(args[0]);
            var editFile = readFile;
            var provider = new DataProvider(editFile);

            var parameters = new CreateNIR4ParameterList();
            var p = parameters.GetParameters(provider);

            var programs = new List<IPrograms>()
            {
                new GetInfo(),
                new ShowOrders(),
                new RemoveExponentials(),
                new FixTolerances(),
                new FixCodes()
            };

            for (var i = 0; i < programs.Count; i++)
                Console.WriteLine($"{ i + 1}: {programs[i].GetName()}");
            Console.WriteLine("Q: Save and Exit");
            Console.WriteLine();

            while (true)
            {
                Console.Write("Choose a program: ");
                var input = Console.ReadLine();
                Console.Clear();
                for (var i = 0; i < programs.Count; i++)
                    Console.WriteLine($"{ i + 1}: {programs[i].GetName()}");
                Console.WriteLine("Q: Save and Exit");
                Console.WriteLine();

                if (input.ToLower().StartsWith("q"))
                    break;

                try
                {
                    var method = int.Parse(input);
                    programs[method - 1].RunProgram(provider);
                    Console.WriteLine();
                }
                catch
                {
                    Console.WriteLine("Invalid selection.");
                    Console.WriteLine();
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
