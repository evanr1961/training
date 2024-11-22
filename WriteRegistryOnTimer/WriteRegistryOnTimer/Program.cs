using System;
using System.Runtime.Versioning;
using System.Timers;
using Microsoft.Win32;

internal class Program
{
    private static System.Timers.Timer _timer = new(5000);
    private const string RegistryKeyPath = @"SOFTWARE\MyApp";
    private const string RegistryValueName = "MyValue";
    private static int _value = 0;
    [SupportedOSPlatform("windows")]
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        // Set up the timer to fire every 5 seconds (5000 milliseconds)
        _timer.Elapsed += OnTimedEvent;
        _timer.AutoReset = true; // Ensures the timer fires repeatedly
        _timer.Enabled = true;

        // Keep the application running to listen for timer events
        Console.WriteLine("Press [Enter] to exit the program.");
        Console.ReadLine();
    }
    [SupportedOSPlatform("windows")]
    private static void OnTimedEvent(Object? source, ElapsedEventArgs e)
    {
        Console.WriteLine("The timer event fired at {0:HH:mm:ss.fff}", e.SignalTime);

        // Example: Write an integer to the registry
        WriteRegistryValue(RegistryKeyPath, RegistryValueName, _value++);

        // Example: Read an integer from the registry
        int value = ReadRegistryValue(RegistryKeyPath, RegistryValueName, -1);
        Console.WriteLine($"Registry value: {value}");
    }

    [SupportedOSPlatform("windows")]
    private static void WriteRegistryValue(string keyPath, string valueName, int value)
    {
        using RegistryKey key = Registry.CurrentUser.CreateSubKey(keyPath);
        key?.SetValue(valueName, value, RegistryValueKind.DWord);
    }

    [SupportedOSPlatform("windows")]
    private static int ReadRegistryValue(string keyPath, string valueName, int defaultValue)
    {
        using (RegistryKey? key = Registry.CurrentUser.OpenSubKey(keyPath))
        {
            if (key?.GetValue(valueName) is int intValue)
            {
                return intValue;
            }
        }
        return defaultValue;
    }
}
