using System;
using System.IO;
using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        using (var ms = new MemoryStream())
        {
            using (var sw = new StreamWriter(ms))
            {
                sw.WriteLine("The values is {0:0.00}", 123.45678);
            }
            Console.WriteLine(Encoding.UTF8.GetString(ms.ToArray()));
        }
    }
}