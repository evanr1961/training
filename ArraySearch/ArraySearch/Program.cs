internal class Program
{
    private static void Main(string[] args)
    {
        string[] strings = new string[] { "one", "two", "three", "four", "five", "six" };

        bool foundIt = false;
        foreach (string s in strings)
        {
            if ("two" == s) { foundIt = true; }
        }

        Console.WriteLine($"foundIt {foundIt}");
    }
}