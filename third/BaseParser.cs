using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace third
{
    internal abstract class BaseParser : ILogParser
    {
        protected abstract Regex Regex { get; }
        protected abstract string DateFormat { get; }
        protected abstract string? ExtractSource(Match match);

        public bool TryParse(string line, out LogModel entry)
        {
            entry = null;
            var match = Regex.Match(line);
            if (!match.Success) return false;

            var level = NormalizeLevel(match.Groups["level"].Value);
            if (level == null) return false;

            if (!DateOnly.TryParseExact(match.Groups["date"].Value, DateFormat,
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out var date))
                return false;

            if (!TimeOnly.TryParse(match.Groups["time"].Value, CultureInfo.InvariantCulture, DateTimeStyles.None, out var time))
                return false;

            entry = new LogModel
            {
                Date = date,
                Time = time,
                Level = level,
                Source = ExtractSource(match) ?? "DEFAULT",
                Message = match.Groups["message"].Value
            };

            return true;
        }

        private static string? NormalizeLevel(string level) => level.ToUpper() switch
        {
            "INFORMATION" => "INFO",
            "INFO" => "INFO",
            "WARNING" => "WARN",
            "WARN" => "WARN",
            "ERROR" => "ERROR",
            "DEBUG" => "DEBUG",
            _ => null
        };
    }
}
