
using Aunir.SpectrumAnalysis.CalibrationEquations.GH;
using Aunir.SpectrumAnalysis.CalibrationEquations.PLS;
using Aunir.SpectrumAnalysis.FileIO;
using Aunir.SpectrumAnalysis.Interfaces;
using Aunir.SpectrumAnalysis.Interfaces.Equations;
using Aunir.SpectrumAnalysis2.Interfaces.Constants;
using JacksUsefulLibrary.NIR4XmlDefinitions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace WPFCalibrationFileEditor
{
    public class XmlFileWriter : IEquationFileWriter
    {
        private Stream outputStream;

        public XmlFileWriter(Stream outputStream)
        {
            this.outputStream = outputStream;
        }

        public void WriteEquationFile(List<ProductDefinition> products)
        {
            new XmlSerializer(typeof(Products)).Serialize(this.outputStream, (object)new Products()
            {                
                ContainedProducts = products.Select<ProductDefinition, Product>
                ((Func<ProductDefinition, Product>)(prod => this.Map(prod.ProductName, prod.Equations, prod.GhEquation, prod.GhLimit))).ToList<Product>()
            });
        }

        private Product Map(string productName, List<IEquation> equations, IEquation ghEquation, double? ghLimit)
        {
            Product product = new Product()
            {
                Name = productName
            };
            product.Calibrations = this.MapPlsEquations(equations);
            product.GhCalibration = this.MapGhEquation(ghEquation, ghLimit);
            return product;
        }
        private List<Calibration> MapPlsEquations(List<IEquation> equations)
        {
            List<Calibration> calibrationList = new List<Calibration>();
            foreach(var equation in equations)
            {
                if (!(equation is PlsEquation))
                {
                    throw new ArgumentException("AunirXmlPlsEquatinoFileWriter can only be used for PLS equations");
                }
                var plsEquation = equation as PlsEquation;
                var calibration = new Calibration()
                {
                    ApplicableInstruments = new List<InstrumentType>((IEnumerable<InstrumentType>)plsEquation.CommonEquationInformation.ApplicableInstruments),
                    Bias = plsEquation.CalibrationBias,
                    Parameter = plsEquation.CommonEquationInformation.Parameter,
                    Version = plsEquation.CommonEquationInformation.Version
                };
                calibration.Coefficients = new List<Coefficient>();
                for (int index = 0; index < plsEquation.Coefficients.Length; ++index)
                {
                    Coefficient coefficient = new Coefficient()
                    {
                        CoefficientValue = plsEquation.Coefficients[index],
                        Wavelength = plsEquation.Wavelengths[index]
                    };
                    calibration.Coefficients.Add(coefficient);
                }
                calibration.Pretreatments = XmlFileWriter.MapPretreatments((IEquation)plsEquation);
                calibrationList.Add(calibration);
            }
            return calibrationList;
        }        

        private GHCalibration MapGhEquation(IEquation ghEquation, double? ghLimit)
        {
            if (!(ghEquation is GhEquation))
            {
                throw new ArgumentException("AunirXmlPlsEquatinoFileWriter can only write GH Calibrations in GhEquation format");
            }
            GhEquation ghEquation1 = ghEquation as GhEquation;
            GHCalibration ghCalibration = new GHCalibration()
            {
                ApplicableInstruments = new List<InstrumentType>((IEnumerable<InstrumentType>)ghEquation1.CommonEquationInformation.ApplicableInstruments),
                Version = ghEquation1.Version,
                GhLimit = ghLimit
            };
            ghCalibration.Factors = new List<Factor>();
            for (int index = 0; index < ghEquation1.FactorsUsed; ++index)
            {
                Factor factor = new Factor()
                {
                    Id = ghEquation1.Scores[index].Factor,
                    InvTqs = ghEquation1.Scores[index].InvTqs,
                    MeanScore = ghEquation1.Scores[index].MeanScore,
                    Loadings = ghEquation1.Loadings[index].loadingsArray
                };
                ghCalibration.Factors.Add(factor);
            }
            ghCalibration.Pretreatments = MapPretreatments((IEquation)ghEquation1);
            return ghCalibration;
        }

        private static List<Pretreatment> MapPretreatments(IEquation equation)
        {
            List<Pretreatment> pretreatmentList = new List<Pretreatment>();
            foreach (IPretreatmentInfo pretreatment1 in equation.CommonEquationInformation.Pretreatments)
            {
                Pretreatment pretreatment2 = new Pretreatment();
                pretreatment2.Type = pretreatment1.GetPretreatmentType();
                switch (pretreatment1.GetPretreatmentType())
                {
                    case "Trim":
                        pretreatment2.Parameters.Add(new PretreatmentParameter()
                        {
                            ParameterType = "minWavelength",
                            Value = pretreatment1.GetSetting("minWavelength").ToString()
                        });
                        pretreatment2.Parameters.Add(new PretreatmentParameter()
                        {
                            ParameterType = "maxWavelength",
                            Value = pretreatment1.GetSetting("maxWavelength").ToString()
                        });
                        break;
                    case "Derivative":
                        pretreatment2.Parameters.Add(new PretreatmentParameter()
                        {
                            ParameterType = "gap",
                            Value = pretreatment1.GetSetting("gap").ToString()
                        });
                        break;
                    case "Smooth":
                        pretreatment2.Parameters.Add(new PretreatmentParameter()
                        {
                            ParameterType = "amount",
                            Value = pretreatment1.GetSetting("amount").ToString()
                        });
                        break;
                    case "Reduce":
                        pretreatment2.Parameters.Add(new PretreatmentParameter()
                        {
                            ParameterType = "resolution",
                            Value = pretreatment1.GetSetting("resolution").ToString()
                        });
                        break;
                }
                pretreatmentList.Add(pretreatment2);
            }
            return pretreatmentList;
        }
    }
}
