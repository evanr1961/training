internal class Program
{
    private static void Main(string[] args)
    {
        OrdinaryHuman Bill = new(195);
        Bill.GoToWork();
        Bill.PayBills();
        Console.WriteLine(Bill.BreakWalls(0.95F));

        Console.WriteLine("Get It Done!");
    }
    public sealed class OrdinaryHuman
    {
        private int age;
        int weight;

        public OrdinaryHuman(int weight)
        {
            this.weight = weight;
        }

        public void GoToWork() { Console.WriteLine("Work'n, Work'n, Work'n, ..."); }
        public void PayBills() { Console.WriteLine("Pay Bills"); }
    }
}
static class AmazeballsSerum
{
    public static string BreakWalls(this Program.OrdinaryHuman h, double wallDensity)
    {
        return ($"I broke through a wall of {wallDensity} density.");
    }
}