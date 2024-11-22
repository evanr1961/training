using System.Collections.Generic;
internal class Program
{
    private static void Main(string[] args)
    {
        Dictionary<int, RetiredPlayer> retiredYankees = new()
        {
            { 3, new RetiredPlayer("Babe Ruth", 1948) },
            { 4, new RetiredPlayer("Lou Gehrig", 1939) },
            { 5, new RetiredPlayer("Joe DiMaggio", 1952) },
            { 7, new RetiredPlayer("Mickey Mantle", 1969) },
            { 8, new RetiredPlayer("Yogi Berra", 1972) },
            { 10, new RetiredPlayer("Phil Rizzuto", 1985) },
            { 23, new RetiredPlayer("Don Mattingly", 1997) },
            { 42, new RetiredPlayer("Jakei Robinson", 1993) },
            { 44, new RetiredPlayer("Reggie Jackson", 1993) },

        };

        foreach(int jerseyNumber in retiredYankees.Keys)
        {
            RetiredPlayer player = retiredYankees[jerseyNumber];
            Console.WriteLine($"{player.Name} #{jerseyNumber}");
        }

        Console.WriteLine("Hello, World!");
    }

    public class RetiredPlayer
    {
        public string Name { get; set; }
        public int YearRetried { get; set; }

        public RetiredPlayer(string name, int yearRetired)
        {
            Name = name;
            YearRetried = yearRetired;
        }
    }
}