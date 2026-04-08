using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace third;

internal class LogModel
{
    public DateOnly Date { get; set; }
    public TimeOnly Time { get; set; }
    public string Message { get; set; }
    public string Level { get; set; }
    public string Source { get; set; }


    // Переопределяем ToString для финального форматирования при записи в файл.
    public override string ToString() =>    
         $"{Date:dd-MM-yyyy}\t{Time:HH:mm:ss.ffff}\t{Level}\t{Source}\t{Message}";
}
