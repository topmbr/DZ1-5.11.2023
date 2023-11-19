namespace ConsoleApp73
{
    class Program
    {
        static Mutex mutex = new Mutex();
        static int count = 20;
        static int count1 = 10;

        static void Main()
        {
            Thread firstThread = new Thread(CountUp);
            Thread secondThread = new Thread(CountDown);

            firstThread.Start();
            secondThread.Start();

            firstThread.Join();
            secondThread.Join();
        }

        static void CountUp()
        {
            mutex.WaitOne();

            for (int i = 0; i <= count; i++)
            {
                Console.WriteLine($"Thread 1: {i}");
                Thread.Sleep(100);
            }

            mutex.ReleaseMutex();
        }

        static void CountDown()
        {
            mutex.WaitOne();

            for (int i = count1; i >= 0; i--)
            {
                Console.WriteLine($"Thread 2: {i}");
                Thread.Sleep(100);
            }

            mutex.ReleaseMutex();
        }
    }
}