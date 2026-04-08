using System.Globalization;
using System.Reflection.Emit;
using System.Text.RegularExpressions;

namespace third;

/*
    Можно считать, что в сообщении могут встречаться любые символы, кроме переноса строки, от чего split может давать ложные ошибки в корректных логах.
    так же, по примеру из тз в данном формате нет источника, поэтому его можно заполнять константой "DEFAULT".
    Можно было бы сделать более сложный парсер, который бы пытался распарсить дату и время, а потом уже выделять уровень и сообщение, но это будет избыточно для данного формата, так как он достаточно строгий.
*/

internal class Format1Parser : BaseParser
{
    protected override Regex Regex => new Regex(
        @"^(?<date>\d{2}\.\d{2}\.\d{4})\s+
          (?<time>\d{2}:\d{2}:\d{2}\.\d+)\s+
          (?<level>\w+)\s+
          (?<message>.+)$",
        RegexOptions.Compiled | RegexOptions.IgnorePatternWhitespace);

    protected override string DateFormat => "dd.MM.yyyy";

    protected override string ExtractSource(Match match) => "DEFAULT";
}

