internal class Program
{
    private static void Main(string[] args)
    {
        Bird bird;
        Console.Write("\nPress P for pideon,  O for Ostrich: ");
        char key = Char.ToUpper(Console.ReadKey().KeyChar);
        if (key == 'P') bird = new Pideon();
        else if (key == 'O') bird = new Ostrich();
        else return;

        Console.Write("\nHow many eggs should it lay?: ");
        string? count = Console.ReadLine();
        if (!int.TryParse(count, out int numberOfEggs)) return;
        Console.WriteLine("\n");
        Egg[] eggs = bird.LayEggs(numberOfEggs);
        foreach (Egg egg in eggs)
        {
            Console.WriteLine(egg.Description);
        }
    }

    class Bird
    {
        public static Random Randomizer = new Random();
        public virtual Egg[] LayEggs(int numberOfEggs)
        {
            Console.Error.WriteLine("Bird.LayEggs should never get called");
            return new Egg[0];
        }
    }
    class Pideon : Bird 
    {
        public override Egg[] LayEggs(int numberOfEggs)
        {
            Egg[] eggs = new Egg[numberOfEggs];
            for (int i = 0; i < numberOfEggs; i++)
            {
                if (Bird.Randomizer.Next(4) == 0)
                {
                    eggs[i] = new BrokenEgg("white");
                }
                else
                {
                    eggs[i] = new Egg(Bird.Randomizer.NextDouble() * 3 + 1, "White");
                }
            }
            return eggs;
        }

    }

    class Ostrich : Bird
    {

        public override Egg[] LayEggs(int numberOfEggs)
        {
            Egg[] eggs = new Egg[numberOfEggs];
            for (int i = 0; i < numberOfEggs; i++)
            {
                eggs[i] = new Egg(Bird.Randomizer.NextDouble()*3+11, "Speckled");
            }
            return eggs;
        }
    }

    class Egg
    {
        public double Size {  get; private set; }
        public string Color {  get; private set; }
        public Egg(double size, string color)
        {
            Size = size;
            Color = color;
        }
        public string Description 
        { 
            get { return $"A {Size:0.0}cm {Color} egg"; } 
        }
    }

    class BrokenEgg : Egg
    {
        public BrokenEgg(string color) : base(0, $"broken {color}")
        {
            Console.WriteLine("A bird laid a broken egg");
        }
    }
}
