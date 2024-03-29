﻿using System.Text.RegularExpressions;

namespace NIR4CalibrationEditorMethods.Domain
{
    public static class RegularExpressions
    {
        //example parameter line = <parameter tolerance="2.5" label="Dry Matter" unit=" % " order="0">DM</parameter> 
        //groups: 1=tolerance, 2=label, 3=unit, 4=order, 5=code

        public static Regex findExponential = new Regex(@"-?[0-9]\.[0-9]+[eE][+-][0-9]{1,2}");

        public static Regex findProductName = new Regex(@"<name>(?<product>[^<]*)</name>");

        public static Regex findEmptyParameter = new Regex(@"<parameter>(?<code>[^<]*)</parameter>");

        public static Regex findParameterGroups = new Regex(
            @"
            <parameter \s tol
            [^""]+ "" (?<tolerance>[^""]+) ""
            [^""]+ "" (?<label>[^""]+) ""
            [^""]+ "" (?<unit>[^""]*) ""
            [^""]+ "" (?<order>[^""]+) ""
            > (?<code>[^<]+) < [^>]+ >
            ",
            RegexOptions.IgnorePatternWhitespace);

        public static Regex findWavelengthAndLoading = new Regex(@"<coefficient wavelength=""(?<wavelength>[0-9]*)"">(?<loading>[^<]*)</coefficient>");

        public static Regex findMinMaxWavelengths = new Regex(@"<parameter name=""(?<minmax>min|max)Wavelength"">(?<wavelength>[0-9]+)</parameter>");

        //public static Regex findMinWavelengths = new Regex(@"<parameter name=""minWavelength"">(?<wavelength>[0-9]+)</parameter>");
        //public static Regex findMaxWavelengths = new Regex(@"<parameter name=""maxWavelength"">(?<wavelength>[0-9]+)</parameter>");
    }
}
