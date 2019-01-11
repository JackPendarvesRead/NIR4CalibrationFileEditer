using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFCalibrationFileEditor.UnitTests
{
    internal class ConvertPlsxProcessTestsData
    {
        internal string Data => 
        @"here is the first line
        and another line
        one more random one
        <parameter tolerance=""2.5"" label=""ME"" unit=""MJ / kg"" order=""1"">ME</parameter>
        <parameter tolerance=""2.5"" label=""Protein"" unit=""%"" order=""2"">Protein</parameter>
        <parameter>Empty</parameter>
        <parameter tolerance=""2.5"" label=""Moisture"" unit=""%"" order=""3"">Moisture</parameter>
        one in the middle
        <limit>5</limit>
        <coefficient wavelength=""930"">9.96811580657959</coefficient>
        <coefficient wavelength=""936"">13.255842208862305</coefficient>
        <coefficient wavelength=""942"">-18.207420349121094</coefficient>
        <coefficient wavelength=""948"">-38.743450164794922</coefficient>
        <coefficient wavelength=""954"">-1.0709664821624756</coefficient>
        <coefficient wavelength=""960"">62.823383331298828</coefficient>
        <coefficient wavelength=""966"">78.611701965332031</coefficient>
        <coefficient wavelength=""972"">47.833827972412109</coefficient>
        <coefficient wavelength=""978"">20.133575439453125</coefficient>
        <coefficient wavelength=""984"">-102.66737365722656</coefficient>
        <coefficient wavelength=""990"">-108.39445495605469</coefficient>
        <coefficient wavelength=""996"">26.065139770507812</coefficient>
        <coefficient wavelength=""1002"">20.954925537109375</coefficient>
        <coefficient wavelength=""1008"">-5.9024615287780762</coefficient>
        <coefficient wavelength=""1014"">39.836956024169922</coefficient>
        <coefficient wavelength=""1020"">115.16333770751953</coefficient>
        <coefficient wavelength=""1026"">-83.437347412109375</coefficient>
        <coefficient wavelength=""1032"">-238.32023620605469</coefficient>
        <coefficient wavelength=""1038"">-152.82418823242188</coefficient>
        <coefficient wavelength=""1044"">-135.80757141113281</coefficient>
        <coefficient wavelength=""1050"">-79.295600891113281</coefficient>
        <coefficient wavelength=""1056"">122.69586944580078</coefficient>
        <coefficient wavelength=""1062"">-0.41897794604301453</coefficient>
        <coefficient wavelength=""1068"">-29.071231842041016</coefficient>
        <parameter tolerance=""2.5"" label=""Dry Matter"" unit=""%"" order=""4"">DM</parameter>
        last line with 1245u9 random stuff and222388 ~:: longer
        <coefficientwavelength=""1530"">-1.10254669189453E-05</coefficient>
        <coefficientwavelength=""1536"">-168.95988464355469</coefficient>
        <coefficientwavelength=""1542"">37.722461700439453</coefficient>
        <coefficientwavelength=""1548"">92.237228393554688</coefficient>
        <coefficientwavelength=""1554"">-136.02278137207031</coefficient>
        <coefficientwavelength=""1560"">-212.12039184570313</coefficient>
        <coefficientwavelength=""1566"">2.30233764648438E-12</coefficient>
        <coefficientwavelength=""1572"">396.65704345703125</coefficient>
        <coefficientwavelength=""1578"">131.90451049804688</coefficient>
        <coefficientwavelength=""1584"">-211.53007507324219</coefficient>
        <coefficientwavelength=""1590"">-1.94429016113281E+08</coefficient>
        <coefficientwavelength=""1596"">-186.69378662109375</coefficient>
        <coefficientwavelength=""1602"">-231.27536010742188</coefficient>
        <coefficientwavelength=""1608"">-95.744232177734375</coefficient>
        <coefficientwavelength=""1614"">-15.558786392211914</coefficient>
        <coefficientwavelength=""1620"">-36.51898193359375</coefficient>
        <coefficientwavelength=""1626"">45.297946929931641</coefficient>
        <coefficientwavelength=""1632"">56.294769287109375</coefficient>
        <coefficientwavelength=""1638"">114.84611511230469</coefficient>
        <coefficientwavelength=""1644"">142.1915283203125</coefficient>";

        internal string ExpectedData =>
        @"here is the first line
        and another line
        one more random one
        <parameter tolerance=""2.5"" label=""ME"" unit=""MJ / kg"" order=""1"">ME</parameter>
        <parameter tolerance=""2.5"" label=""Protein"" unit=""%"" order=""2"">Protein</parameter>
        <parameter tolerance=""2.5"" label=""Empty"" unit=""%"" order=""0"">Empty</parameter>
        <parameter tolerance=""2.5"" label=""Moisture"" unit=""%"" order=""3"">Moisture</parameter>
        one in the middle
        <ghLimit>5</ghLimit>
        <coefficient wavelength=""930"">9.96811580657959</coefficient>
        <coefficient wavelength=""936"">13.255842208862305</coefficient>
        <coefficient wavelength=""942"">-18.207420349121094</coefficient>
        <coefficient wavelength=""948"">-38.743450164794922</coefficient>
        <coefficient wavelength=""954"">-1.0709664821624756</coefficient>
        <coefficient wavelength=""960"">62.823383331298828</coefficient>
        <coefficient wavelength=""966"">78.611701965332031</coefficient>
        <coefficient wavelength=""972"">47.833827972412109</coefficient>
        <coefficient wavelength=""978"">20.133575439453125</coefficient>
        <coefficient wavelength=""984"">-102.66737365722656</coefficient>
        <coefficient wavelength=""990"">-108.39445495605469</coefficient>
        <coefficient wavelength=""996"">26.065139770507812</coefficient>
        <coefficient wavelength=""1002"">20.954925537109375</coefficient>
        <coefficient wavelength=""1008"">-5.9024615287780762</coefficient>
        <coefficient wavelength=""1014"">39.836956024169922</coefficient>
        <coefficient wavelength=""1020"">115.16333770751953</coefficient>
        <coefficient wavelength=""1026"">-83.437347412109375</coefficient>
        <coefficient wavelength=""1032"">-238.32023620605469</coefficient>
        <coefficient wavelength=""1038"">-152.82418823242188</coefficient>
        <coefficient wavelength=""1044"">-135.80757141113281</coefficient>
        <coefficient wavelength=""1050"">-79.295600891113281</coefficient>
        <coefficient wavelength=""1056"">122.69586944580078</coefficient>
        <coefficient wavelength=""1062"">-0.41897794604301453</coefficient>
        <coefficient wavelength=""1068"">-29.071231842041016</coefficient>
        <parameter tolerance=""2.5"" label=""Dry Matter"" unit=""%"" order=""4"">DM</parameter>
        last line with 1245u9 random stuff and222388 ~:: longer
        <coefficientwavelength=""1530"">-0.0000110254669189453</coefficient>
        <coefficientwavelength=""1536"">-168.95988464355469</coefficient>
        <coefficientwavelength=""1542"">37.722461700439453</coefficient>
        <coefficientwavelength=""1548"">92.237228393554688</coefficient>
        <coefficientwavelength=""1554"">-136.02278137207031</coefficient>
        <coefficientwavelength=""1560"">-212.12039184570313</coefficient>
        <coefficientwavelength=""1566"">0.00000000000230233764648438</coefficient>
        <coefficientwavelength=""1572"">396.65704345703125</coefficient>
        <coefficientwavelength=""1578"">131.90451049804688</coefficient>
        <coefficientwavelength=""1584"">-211.53007507324219</coefficient>
        <coefficientwavelength=""1590"">-194429016.113281</coefficient>
        <coefficientwavelength=""1596"">-186.69378662109375</coefficient>
        <coefficientwavelength=""1602"">-231.27536010742188</coefficient>
        <coefficientwavelength=""1608"">-95.744232177734375</coefficient>
        <coefficientwavelength=""1614"">-15.558786392211914</coefficient>
        <coefficientwavelength=""1620"">-36.51898193359375</coefficient>
        <coefficientwavelength=""1626"">45.297946929931641</coefficient>
        <coefficientwavelength=""1632"">56.294769287109375</coefficient>
        <coefficientwavelength=""1638"">114.84611511230469</coefficient>
        <coefficientwavelength=""1644"">142.1915283203125</coefficient>";

    }
}
