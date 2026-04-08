namespace third
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var processor = new LogProcessor();

            processor.Process(
                "input.txt",
                "output.txt",
                "problems.txt");

            Console.WriteLine("Processing completed. Check output.txt and problems.txt for results.");
        }
    }
}
