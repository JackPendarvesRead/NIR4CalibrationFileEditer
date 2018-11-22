using System;
using System.Collections.Generic;
using System.IO;
using Aunir.SpectrumAnalysis.CalibrationEquations.PLS;
using Aunir.SpectrumAnalysis.FileIO;
using Aunir.SpectrumAnalysis.FileIO.AunirXml;
using Aunir.SpectrumAnalysis.FileIO.Foss.GH;
using Aunir.SpectrumAnalysis.Interfaces;
using Aunir.SpectrumAnalysis.Interfaces.Equations;
using WPFCalibrationFileEditor.Domain;

namespace WPFCalibrationFileEditor
{
    public class SimonFileSaver
    {
        public void SetupProduct(Product product)
        {            
            ProductDefinition productDefinition = new ProductDefinition();
            productDefinition.GhEquation = GetGh(product.GhFileName, product.GhVersion);
            productDefinition.GhEquation.CommonEquationInformation.ApplicableInstruments = new InstrumentType[1] { product.ApplicableInstrument };
            productDefinition.ProductName = product.Name;
            productDefinition.Equations = new List<IEquation>();
            foreach (Calibration cal in product.Calibrations)
            {
                if (cal.IncludeCalibration)
                {
                    PlsEquation pls = cal.Equation as PlsEquation;
                    pls.CommonEquationInformation.ApplicableInstruments = new InstrumentType[1] { product.ApplicableInstrument };
                    pls.CommonEquationInformation.Version = cal.Version;
                    pls.CommonEquationInformation.Parameter = cal.Name;
                    productDefinition.Equations.Add(pls);
                }
                productDefinition.GhLimit = product.GhLimit;
            }            
        }

        private IEquation GetGh(string fileName, string version)
        {
            FossGhEquationReader ghFileReader = new FossGhEquationReader();
            FileInfo selectedFile = new FileInfo(fileName);
            string removedExtension = selectedFile.FullName.Remove(selectedFile.FullName.Length - selectedFile.Extension.Length);

            using (FileStream pcaFile = new FileStream(removedExtension + ".pca", FileMode.Open))
            using (FileStream libFile = new FileStream(removedExtension + ".lib", FileMode.Open))
            {
                return ghFileReader.ReadFile(libFile, pcaFile, version);
            }
            throw new Exception("Error reading GH file");
        }
    }
}
