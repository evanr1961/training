internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Welcome to HiLo.");
        Console.WriteLine($"Guess numbers between 1 and {HiLoGame.MAXIMUM}.");
        HiLoGame.Hint();
        while (HiLoGame.Pot > 0)
        {
            Console.WriteLine("Press h for higher, l for lower, ? to buy a hint,");
            Console.WriteLine($"or any other key to quit.");
            Console.WriteLine($"Current Pot = {HiLoGame.Pot}.");
            char key = Console.ReadKey(true).KeyChar;
            if (key == 'h') HiLoGame.Guess(true);
            else if (key == 'l') HiLoGame.Guess(false);
            else if (key == '?') HiLoGame.Hint();
            else return;
        }
    }
}
static class HiLoGame
{
    public const int MAXIMUM = 10;
    static private Random random = new();
    static private int currentNumber = random.Next(MAXIMUM);
    static private int pot = 10;
    static public int Pot
    {
        get { return pot; }
        private set { pot = value; }
    }

    static public void Guess( bool higher)
    {
        int next = random.Next(MAXIMUM);
        if ((higher && (next >= currentNumber)) || 
            (!higher && (next < currentNumber)))
        {
            Console.WriteLine("You guessed right!");
            Pot++;
        }
        else
        {
            Console.WriteLine("Bad luck you guessed wrong.");
            Pot--;
        }

        currentNumber = next;

    }

    static public void Hint() 
    {
        int half = MAXIMUM / 2;
        if (currentNumber >= half) 
        { 
            Console.WriteLine($"The number is at least {half}"); 
        }
        else 
        { 
            Console.WriteLine($"The number is at most {half}");  
        }
        Pot--;
    }
}