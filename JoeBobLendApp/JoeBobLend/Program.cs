internal class Program
{
    private static void Main(string[] args)
    {
        Guy Joe = new Guy() { Name ="Joe", Cash=50};
        Guy Bob = new Guy() { Name ="Bob", Cash=100};

        while (true)
        {
            Joe.WriteMyInfo();
            Bob.WriteMyInfo();

            Console.Write("Enter an Amount:");
            string? howMuch = Console.ReadLine();
            if (howMuch == "") { return; }

            if (int.TryParse(howMuch, out int amount) == true)
            {
                Console.Write("Who should give the Cash: ");
                string? whichGuy = Console.ReadLine();
                if (String.IsNullOrWhiteSpace(whichGuy)) { return; }
                if (whichGuy == "Joe")
                {
                    Bob.ReceiveCash(Joe.GiveCash(amount));
                }
                else if (whichGuy == "Bob")
                {
                    Joe.ReceiveCash(Bob.GiveCash(amount));
                }
                else
                {
                    Console.WriteLine("Please enter 'Joe' or 'Bob' ");
                }

            }
            else
            {
                Console.WriteLine("Please enter an amount (or a blank line to exit).");
            }
        }
    }
}

class Guy
{
    public string Name = "Undefined";
    public int Cash;

    public void WriteMyInfo()
    {
        Console.WriteLine(Name + " has " + Cash + " bucks.");
    }

    public int GiveCash(int amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine(Name + " says " + amount + " isn't a valid amount");
            return 0;
        }
        if (amount > Cash)
        {
            Console.WriteLine(Name + "says: " +
                "I don't have enoungh cash to give you" + amount);
            return 0;
        }
        Cash -= amount;
        return amount;
    }

    public void ReceiveCash(int amount) 
    {
        if (amount <= 0)
        {
            Console.WriteLine(Name + " says: " + amount + "isn't an amount I'll take");

        }
        else
        {
            Cash += amount;
        }
    }
}