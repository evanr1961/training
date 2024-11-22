internal class Program
{
    private static void Main(string[] args)
    {
        var array = new int[] { 1, 2, 3, 4 };
        var result = array.Select (i => i * 2);

        foreach (var i in result)
        {
            Console.WriteLine(i);
        }

        Console.WriteLine("==========================");

        int[] values = { 0, 12, 44, 36, 92, 54, 13, 8 };
        IEnumerable<int> result2 =
            from v in values
            where v < 37
            orderby v descending
            select v;

        foreach(var i in result2)
        {
            Console.WriteLine(i);
        }

        Console.WriteLine("==========================");

        IEnumerable<int> result3 = values.Where(v => v < 37).OrderBy(v => -v);

        foreach (var i in result3)
        {
            Console.WriteLine(i);
        }
    }
}