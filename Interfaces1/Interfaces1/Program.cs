internal class Program
{
    interface IClown
    {
        void Honk();
        string FunnyThingIHave {  get; }

    }

    class TallGuy : IClown
    {
        public string Name = "John Doe";
        public string Height = "0";

        public void TalkAboutYourself()
        {
            Console.WriteLine($"My name is {Name} and I am {Height} inches tall.");
        }

        //IClown
        public string FunnyThingIHave { get { return "big shoes"; } }

        public void Honk() { Console.WriteLine("Honk, Honk!"); }
    }
    private static void Main(string[] args)
    {
        TallGuy tallguy = new TallGuy() { Name = "Jimmy", Height = "76" };

        tallguy.TalkAboutYourself();
        
        Console.WriteLine($"The tall guy has {tallguy.FunnyThingIHave}");
        tallguy.Honk();
    }
}