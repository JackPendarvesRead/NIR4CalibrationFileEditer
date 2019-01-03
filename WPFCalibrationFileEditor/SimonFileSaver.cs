using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Aunir.SpectrumAnalysis.CalibrationEquations.PLS;
using Aunir.SpectrumAnalysis.FileIO;
using Aunir.SpectrumAnalysis.FileIO.AunirXml;
using Aunir.SpectrumAnalysis.FileIO.Foss.GH;
using Aunir.SpectrumAnalysis.Interfaces;
using Aunir.SpectrumAnalysis.Interfaces.Equations;
using Aunir.SpectrumAnalysis2.Interfaces.Constants;
using Aunir.SpectrumAnalysis2.Interfaces.Pls;
using WPFCalibrationFileEditor.Domain;

namespace WPFCalibrationFileEditor
{
    public class SimonFileSaver
    {
        public void SaveFile(string filePath, Product product)
        {     
            using (FileStream output = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.Delete))
            {
                XmlFileWriter xmlFile = new XmlFileWriter(output);
                xmlFile.WriteEquationFile(GetProductDefinitions(filePath, product));
                output.Flush();
            }
        }

        private List<ProductDefinition> GetProductDefinitions(string filePath, Product product)
        {
            var productDefinitionList = new List<ProductDefinition>();
            var productDefinition = new ProductDefinition();
            productDefinition.GhEquation = GetGh(product.GhFileName, product.GhVersion);
            productDefinition.GhEquation.CommonEquationInformation.ApplicableInstruments = new InstrumentType[1] { product.ApplicableInstrument };
            productDefinition.ProductName = product.Name;
            productDefinition.Equations = new List<IEquation>();
            foreach (Calibration cal in product.Calibrations)
            {
                if (cal.IncludeCalibration)
                {
                    var pls = EquationAdapter.Create(cal.Equation);
                    pls.CommonEquationInformation.ApplicableInstruments = new InstrumentType[1] { product.ApplicableInstrument };
                    pls.CommonEquationInformation.Version = cal.Version;
                    pls.CommonEquationInformation.Parameter = cal.Name;
                    productDefinition.Equations.Add(pls);
                }
                productDefinition.GhLimit = product.GhLimit;
            }
            productDefinitionList.Add(productDefinition);
            return productDefinitionList;
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

        private class EquationAdapter
        {
          
            private static EquationInfo GenerateInfo(IPlsEquationInformation eq)
            {
                return new EquationInfo
                {
                    ApplicableInstruments = new InstrumentType[] { InstrumentType.JDSUMicroNir },
                    Parameter = eq.Parameter,
                    Version = "1.0.0.0",
                    Pretreatments = (from p in eq.Pretreatments select new PretreatmentInfoAdapter(p)).ToArray(),
                    Information = new Dictionary<string, string>()
                };
            }

            public static IEquation Create(IPlsEquationInformation eq)
            {
                var pls = new PlsEquation(new float[eq.Equation.Coefficients.Count()], eq.Equation.Coefficients.ToArray(), Convert.ToSingle(eq.Equation.Intercept), GenerateInfo(eq));
                return pls;
            }
        }

        private class PretreatmentInfoAdapter : IPretreatmentInfo
        {
            private readonly Aunir.SpectrumAnalysis2.Interfaces.Pretreatments.IPretreatmentBlueprint pretreatment;

            public PretreatmentInfoAdapter(Aunir.SpectrumAnalysis2.Interfaces.Pretreatments.IPretreatmentBlueprint pretreatment)
            {
                this.pretreatment = pretreatment;
            }

            public string GetPretreatmentType()
            {
                return pretreatment.PretreatmentType;
            }

            public object GetSetting(string setting)
            {
                string newSetting = "";
                switch (setting)
                {
                    case "minWavelength":
                        newSetting = PretreatmentConstants.TrimMinimumWavelengthSetting.Name;                    
                        break;
                    case "maxWavelength":
                        newSetting = PretreatmentConstants.TrimMaximumWavelengthSetting.Name;
                        break;
                    case "gap":
                        newSetting = PretreatmentConstants.DerivativeGapSetting.Name;
                        break;
                    case "amount":
                        newSetting = PretreatmentConstants.SmoothAmountSetting.Name;
                        break;
                    case "resolution":
                        newSetting = PretreatmentConstants.ReduceFactorSetting.Name;
                        break;
                }


                return (from s in pretreatment.Settings
                       where s.SettingName == newSetting
                       select s.Setting).First();
            }
        }
    }
}
