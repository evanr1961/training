
internal class Program
{
    interface IClown
    {
        string FunnyThingIHave { get; }
        void Honk();
    }

    class TallGuy : IClown
    {
        public string Name = "Undefined";
        public int Height;

        public string FunnyThingIHave => "big red shoes";

        public void Honk() => Console.WriteLine("Honk honk!");
        
        public void Sound(string noise) => Console.WriteLine($"{noise} {noise} {noise}");

        public void TalkeAboutYourself()
        {
            Console.WriteLine($"My name is {Name} and I'm {Height} inches tall.");
            Sound("Sqeak");
            Sound("Honk");
        }
    }
    private static void Main(string[] args)
    {
        TallGuy tallGuy = new TallGuy() { Height = 76, Name = "Jimmy" };
        tallGuy.TalkeAboutYourself();
        Console.WriteLine($"The tall guy has {tallGuy.FunnyThingIHave}");
        tallGuy.Honk();
    }
}