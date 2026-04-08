namespace second
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Читатели
            for (int i = 1; i <= 5; i++)
            {
                Task.Run(() =>
                {
                    while (true)
                    {
                        Console.WriteLine($"Поток {Thread.CurrentThread.ManagedThreadId} прочитал значение: {Server.GetCount()}");
                        Thread.Sleep(200);
                    }
                });
            }

            // Писатель 1
            Task.Run(() =>
            {
                while (true)
                {
                    Thread.Sleep(1000);
                    Console.WriteLine($"Поток {Thread.CurrentThread.ManagedThreadId} добавляет 1 к счетчику.");
                    Server.AddToCount(1);
                }
            });

            // Писатель 2
            Task.Run(() =>
            {
                while (true)
                {
                    Thread.Sleep(1500);
                    Console.WriteLine($"Поток {Thread.CurrentThread.ManagedThreadId} добавляет 10 к счетчику.");
                    Server.AddToCount(10);
                }
            });
            Console.ReadKey();
        }
    }
}
