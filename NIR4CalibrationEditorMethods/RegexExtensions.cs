using System.Text;
using System.Text.RegularExpressions;

namespace NIR4CalibrationEditorMethods
{
    public static class RegexExtensions
    {
        public static string ReplaceGroup(this Regex regex, string input, string groupName, string replacement)
        {
            return regex.Replace(
                input,
                match =>
                {
                    var group = match.Groups[groupName];
                    var sb = new StringBuilder();
                    var previousCaptureEnd = 0;
                    foreach (Capture capture in group.Captures)
                    {
                        var currentCaptureEnd = capture.Index + capture.Length - match.Index;
                        var currentCaptureLength = capture.Index - match.Index - previousCaptureEnd;
                        sb.Append(match.Value.Substring(previousCaptureEnd, currentCaptureLength));
                        sb.Append(replacement);
                        previousCaptureEnd = currentCaptureEnd;
                    }
                    sb.Append(match.Value.Substring(previousCaptureEnd));

                    return sb.ToString();
                });
        }
    }
}
