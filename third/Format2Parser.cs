using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace third;

internal class Format2Parser : BaseParser
{
    protected override Regex Regex => new Regex(
        @"^(?<date>\d{4}-\d{2}-\d{2})\s+
          (?<time>\d{2}:\d{2}:\d{2}\.\d+)\|\s*
          (?<level>\w+)\|\d+\|
          (?<method>[^|]+)\|\s*
          (?<message>.+)$",
        RegexOptions.Compiled | RegexOptions.IgnorePatternWhitespace);

    protected override string DateFormat => "yyyy-MM-dd";

    protected override string ExtractSource(Match match) => match.Groups["method"].Value;
}
