internal class Program
{
    private static void Main(string[] args)
    {
        IClown.CarCapacity = 18;
        Console.WriteLine(IClown.ClownCarDescription());

        IClown fingersTheClown = new ScaryScary("big red nose", 14);
        fingersTheClown.Honk();

        
        if(fingersTheClown is IScaryClown iScaryClownReference )
        {
            iScaryClownReference.ScareAdults();
        }
    }
    interface IClown
    {
        string FunnyThingIHave { get; }
        void Honk();

        protected static Random random = new Random();

        private static int carCapacity = 12;
        public static int CarCapacity
        {
            get { return carCapacity; }
            set
            {
                if (value > 10) carCapacity = value;
                else
                {
                    Console.Error.WriteLine($"Warning: Car capaciity {value} is too small");
                }
            }
        }

        public static string ClownCarDescription()
        {
            return $"A clown care with {random.Next(CarCapacity / 2, CarCapacity)} clowns";
        }
    }

    interface IScaryClown : IClown 
    {
        string ScaryThingIHave { get; }
        void ScareLittleChildren();

        void ScareAdults()
        {
            Console.WriteLine($@"I am an ancient evil that will haunt your dreams.
Behold my terrifying necklace with {random.Next(4, 10)} of my last victim's fingers.

Oh, also before I forget ...");
            ScareLittleChildren();
        }
    }

    class FunnyFunny: IClown
    {
        private string funnyThingIHave;

        public FunnyFunny(string funnyThingIHave)
        {
            this.funnyThingIHave = funnyThingIHave;
        }

        public string FunnyThingIHave { get { return funnyThingIHave; } }

        public void Honk() 
        {
            Console.WriteLine($"Hi Kids! I have a {funnyThingIHave}.");
        }
    }

    class ScaryScary : FunnyFunny, IScaryClown
    {
        private int scaryThingCount;
        private string scaryThingIHave = "spiders";

        public ScaryScary(string funnyThingIHave, int scaryThingCount) : base(funnyThingIHave)
        {
            this.scaryThingCount = scaryThingCount;
        }

        public string ScaryThingIHave { get { return $"{scaryThingCount} {scaryThingIHave}"; } }

        public void ScareLittleChildren()
        {
            Console.WriteLine($"Boo! Gotcha! Look at my {scaryThingCount} {scaryThingIHave}");
        }


    }
}
