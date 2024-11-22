using System.Linq;

internal class Program
{
    private static void Main(string[] args)
    {
        List<int> numbers = new();
        for (int i = 1; i <= 99; i++)
        {
            numbers.Add(i);
        }
        Console.WriteLine("\n=====================");
        IEnumerable<int> firstAndLastFive = numbers.Take(5).Concat(numbers.TakeLast(5));
        foreach(int i in firstAndLastFive)
        {
            Console.Write($"{i} ");
        }

        int[] values = new int[] { 0, 12, 44, 36, 92, 54, 13, 8 };

        IEnumerable<int> result =
                from v in values
                where v < 37
                orderby -v
                select v;

        foreach(int i in result)
            Console.Write($"{i} ");
        Console.WriteLine("\n=====================");

    }
}