namespace first;

internal class Program
{
    static void Main(string[] args)
    {
        var input = Console.ReadLine();
        var compressed = input?.Compress();
        Console.WriteLine($"Original: {input}");
        Console.WriteLine($"Compressed: {compressed}");

        var decompressed = compressed?.DeCompress();
        Console.WriteLine($"Decompressed: {decompressed}");
    }
}
