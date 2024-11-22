internal class Program
{
    private static void Main(string[] args)
    {
        VendingMachine vendingMachine = new AnimalFeedVendingMachine();
        Console.WriteLine(vendingMachine.Dispense(1.00M));
    }

    public class VendingMachine
    {
        public virtual string Item { get; } = "Item is uninitalized.";

        protected virtual bool CheckAmount(decimal money)
        {
            return false;
        }

        public string Dispense(decimal money)
        {
            if (CheckAmount(money)) { return Item; }
            else { return "Please enter the right amount"; }
        }
    }

    public class AnimalFeedVendingMachine : VendingMachine
    {
        public override string Item { get { return "a handful of animal feed"; } }

        protected override bool CheckAmount(decimal money)
        {
            return money > 1.25M;
        }
    }
}
