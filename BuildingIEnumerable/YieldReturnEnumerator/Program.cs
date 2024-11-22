using System.Collections;

internal class Program
{

    static IEnumerable<string> SimpleEnumerable()
    {
        yield return "apples";
        yield return "oranges";
        yield return "bananas";
        yield return "unicorns";
    }
    private static void Main(string[] args)
    {
        foreach (var s in SimpleEnumerable()) { Console.WriteLine(s); }

        var p2 = new PowersOfTwo();
        int i = 0;
        foreach (var powerof2 in p2)
        {
            Console.WriteLine($"Power of Two: Math.Pow(2,{i++}) = {powerof2}");
        }
     }

    class PowersOfTwo : IEnumerable<int>
    {
      public IEnumerator<int> GetEnumerator()
        {
            var maxPower = Math.Round(Math.Log(int.MaxValue, 2));
            for (int power = 0; power < maxPower; power++)
                yield return (int)System.Math.Pow( 2, power);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}