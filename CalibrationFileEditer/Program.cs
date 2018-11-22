using log4net;
using NIR4CalibrationEditorMethods.FileManager;
using NIR4CalibrationEditorMethods.Modules;
using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleCalibrationFileEditer
{
    class Program
    {

        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        static void Main(string[] args)
        {
            log4net.Config.XmlConfigurator.Configure();
            if (!File.Exists(args[0]))
            {
                Log.Error("No arguements when starting program.");
                Console.ReadLine();
                return;                
            }

            Log.Info($"Editting: '{Path.GetFileName(args[0])}'");
            string writeFilePath = new FileSave().GetWriteFilePath(args[0]);
            using (FileStream readStream = new FileStream(args[0], FileMode.Open, FileAccess.Read, FileShare.Delete))
            using (FileStream writeStream = new FileStream(writeFilePath, FileMode.Create, FileAccess.Write, FileShare.Delete))
            {
                var data = new DataProvider(new StreamReader(readStream).ReadToEnd());
                var modules = new List<IModule>()
                {
                    new GetInfo(),
                    new ShowOrders(),
                    new RemoveExponentials(),
                    new FixTolerances(),
                    new FixCodes()
                };
                ProgramLoop programLoop = new ProgramLoop(data);
                programLoop.Run(modules);
                FileSave save = new FileSave();
                save.Save(writeStream, data);
                Log.Info($"File saved successfully {writeFilePath}");                
                Console.ReadLine();
            }
        }       
    }
}
