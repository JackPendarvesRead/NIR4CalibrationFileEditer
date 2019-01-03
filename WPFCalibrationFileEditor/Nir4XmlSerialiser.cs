using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using JacksUsefulLibrary.NIR4XmlDefinitions;

namespace WPFCalibrationFileEditor
{
    public class Nir4XmlSerialiser
    {
        public void SerialiseXml(Stream stream, Product product)
        {
            var serialiser = new XmlSerializer(typeof(Product));
            serialiser.Serialize(stream, product);
        }
    }
}
