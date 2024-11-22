using System.Diagnostics.CodeAnalysis;

internal class Program
{
    private static void Main(string[] args)
    {
        SafeOwner owner = new SafeOwner();
        Safe safe = new Safe();
        JewelThief jewelThief = new JewelThief();
        jewelThief.OpenSafe(safe,owner);
        Console.ReadKey();

        Console.WriteLine("Hello, World!");
    }

    public class Safe
    {
        private string contents = "precious jewels";
        private string safeCombination = "12345";

        public string Open(string combination)
        {
            if (combination == safeCombination) return contents;
            return "";
        }
        public void PickLock(LockSmith lockpicker)
        {
            lockpicker.Combination = safeCombination;
        }
    }

    public class SafeOwner
    {
        private string valuables = "";
        public void ReceiveContents(string safeContents)
        {
            valuables = safeContents;
            Console.WriteLine($"Thank you for returning my {valuables}!");
        }
    }
    public class LockSmith
    {
        public void OpenSafe(Safe safe, SafeOwner owner)
        {
            safe.PickLock(this);
            string safeContents = safe.Open(Combination);
            ReturnContents(safeContents, owner);

        }
        public string Combination { private get; set; } = "Uninitialized";

        protected void ReturnContents(string safeContents, SafeOwner owner)
        {
            owner.ReceiveContents(safeContents);
        }
    }
    public class JewelThief : LockSmith
    {
        private string stolenJewels = "Empty Pockets";
        protected void ReturnContents(string safeContents, SafeOwner owner) { 
            stolenJewels = safeContents;
            Console.WriteLine($"I'm stealing the jewels! I stole: {stolenJewels}");
        }
    }
}
