internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");


        string[] words = { "bot", "apple", "apricot" };
        int minimalLength = words
          .Where(w => w.StartsWith("a"))
          .Min(w => w.Length);
        Console.WriteLine(minimalLength);   // output: 5

        int[] numbers = { 4, 7, 10 };
        int product = numbers.Aggregate(77, 
            (interim, next) => interim * next);
        Console.WriteLine(product);   // output: 280

    }
}