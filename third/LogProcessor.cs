
/*
    Класс для обработки логов.
    Он использует список парсеров для попытки распарсить каждую строку лога.
    Логика разделена на два этапа: сначала попытка распарсить строку, затем нормализация в единый формат.
    Для удобства входные данные передаются в файле inputPath (в примере есть большинство случаев валидных и невалидных логов).
    Если строка успешно распарсена, она записывается в выходной файл, иначе - в файл с проблемами.
 */


namespace third;

internal class LogProcessor
{
    private readonly List<ILogParser> _parsers;

    public LogProcessor()
    {
        _parsers = new List<ILogParser>
        {
            new Format1Parser(),
            new Format2Parser()
        };
    }

    public void Process(string inputPath, string outputPath, string problemsPath)
    {
        using var writer = new StreamWriter(outputPath);
        using var problemWriter = new StreamWriter(problemsPath);

        foreach (var line in File.ReadLines(inputPath))
        {
            if (TryParse(line, out var entry))
            {
                entry.Source = string.IsNullOrWhiteSpace(entry.Source)
                    ? "DEFAULT"
                    : entry.Source;

                writer.WriteLine(entry);
            }
            else
            {
                problemWriter.WriteLine(line);
            }
        }
    }

    private bool TryParse(string line, out LogModel entry)
    {
        foreach (var parser in _parsers)
        {
            if (parser.TryParse(line, out entry))
                return true;
        }

        entry = null;
        return false;
    }

}
