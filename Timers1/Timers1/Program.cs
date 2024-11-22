using System.Timers;
internal class Program
{
    private static void Main(string[] args)
    {
        var Timer = SetTimer();

        Console.WriteLine("\nPress the Enter key to exit the application...\n");
        Console.WriteLine("The application started at {0:HH:mm:ss.fff}", DateTime.Now);
        Console.ReadLine();
        Timer.Stop();
        Timer.Dispose();

        Console.WriteLine("Terminating the application...");
    }

    private static System.Timers.Timer SetTimer()
    {
        var Timer = new System.Timers.Timer(5000);
        Timer.Elapsed += OnTimedEvent;
        Timer.AutoReset = true;
        Timer.Enabled = true;
        return Timer;
    }

    private static void OnTimedEvent(Object? source, ElapsedEventArgs e)
    {
        using (StreamWriter outputFile = new StreamWriter(@"C:\temp\TimerEvents.txt",true))
        {
            outputFile.WriteLine("Timer Event {0:HH:mm:ss.fff}",e.SignalTime);
        }
    }
}