using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        File.WriteAllText("eureka.txt", "Eureka!");
        byte[] eurekaBytes = File.ReadAllBytes("eureka.txt");

        foreach (byte b in eurekaBytes)
        {
            Console.Write("{0} ", b);
        }
        Console.WriteLine(Encoding.UTF8.GetString(eurekaBytes));

        foreach (byte b in eurekaBytes)
        {
            Console.Write("{0:x2} ", b);
        }
        Console.WriteLine();



    }
}