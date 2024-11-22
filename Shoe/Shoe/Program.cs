using System.ComponentModel;

internal class Program
{
    static ShoeCloset shoeCloset = new ShoeCloset();
    private static void Main(string[] args)
    {
        
        while (true)
        {
            string? input = "9";
            char option = '9';

            Console.WriteLine(shoeCloset.ShowCloset());
            Console.Write("Press 'a' to add or 'r' to remove a shoe: ");
            input = Console.ReadLine();
            if (input == null) { option = '9'; }
            else { option = input.Trim()[0]; }
            switch (Char.ToLower(option))
            {
                case 'a':
                    Console.WriteLine("Add a shoe.");
                    ShoeStyle shoeStyle = GetShoeStyle();
                    string color = GetShoeColor();
                    Shoe shoe = new Shoe(shoeStyle, color);
                    shoeCloset.AddShoe(shoe);
                    break;
                case 'r':
                    Console.WriteLine("Enter the number of the shoe to remove:");
                    if (int.TryParse(Console.ReadKey().KeyChar.ToString(), out int shoeNumber) &&
                        (shoeNumber >= 1) && (shoeNumber <= shoeCloset.Shoes.Count()))
                    { 
                         Console.WriteLine($"\nRemoving {shoeCloset.Shoes[shoeNumber - 1].Description}");
                        shoeCloset.RemoveShoe(shoeNumber - 1);
                    }
 
                    
                    break;
            }
        }
    }

    public static ShoeStyle GetShoeStyle()
    {
        ShoeStyle shoeStyle = ShoeStyle.UndefinedShoeStyle;
        char style = '9';

        while (shoeStyle == ShoeStyle.UndefinedShoeStyle)
        {
            Console.WriteLine("Press 0 to add a Sneaker");
            Console.WriteLine("Press 1 to add a Loafer");
            Console.WriteLine("Press 2 to add a Sandal");
            Console.WriteLine("Press 3 to add a Flipflop");
            Console.WriteLine("Press 4 to add a Wingtip");
            Console.WriteLine("Press 5 to add a Clog");
            Console.Write("Enter a style: ");
            string? input = Console.ReadLine();

            if (input == null) { style = '9'; }
            else { style = input.Trim()[0]; }

            switch (style)
            {
                case '0': { shoeStyle = ShoeStyle.Sneaker; break; }
                case '1': { shoeStyle = ShoeStyle.Loafer; break; }
                case '2': { shoeStyle = ShoeStyle.Sandal; break; }
                case '3': { shoeStyle = ShoeStyle.Flipflop; break; }
                case '4': { shoeStyle = ShoeStyle.WingTip; break; }
                case '5': { shoeStyle = ShoeStyle.Clog; break; }
                default:  { shoeStyle = ShoeStyle.UndefinedShoeStyle; break; }
            }
        }
        return shoeStyle;
    }

    public static string GetShoeColor()
    {
        string? color = null;
        while (color == null)
        {
            Console.Write("Enter the color:");
            color = Console.ReadLine().Trim();
        }
        return color;
    }
    class Shoe : IEquatable<Shoe>
    {
        public ShoeStyle? Style { get; private set; }
        public string? Color { get; private set; }

        public Shoe(ShoeStyle? style, string? color)
        {
            Style = style;
            Color = color;
        }
        public string Description
        {
            get { return $"A {Color} {Style}"; }
        }

        public override string ToString()
        {
            return this.Description;
        }

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            Shoe? objAsShoe = obj as Shoe;
            if (objAsShoe == null) return false;
            else return Equals(objAsShoe);
        }
        public override int GetHashCode()
        {
            return Description.GetHashCode();
        }
        public bool Equals(Shoe? other)
        {
            if (other == null) return false;
            return (this.Description.Equals(other.Description));

        }
        public static bool operator==( Shoe lhs, Shoe rhs)
        {
            if (lhs.Equals(rhs)) return true;
            return false;
        }

        public static bool operator!=(Shoe lhs, Shoe rhs)
        {
            if (!(lhs.Equals(rhs))) return true;
            return false;
        }
    }
    public enum ShoeStyle
    {
        UndefinedShoeStyle = -1,
        Sneaker = 0,
        Loafer  = 1,
        Sandal  = 2,
        Flipflop= 3,
        WingTip = 4,
        Clog    = 5,
    }
    class ShoeCloset 
    {
        public List<Shoe> Shoes = new();
        
        public string? ShowCloset()
        {
            if (Shoes.Count == 0) { return "The shoe closet is empty.";  }

            string? inventory = "The shoe closet contains:\n";

            int i = 1;
            foreach(Shoe shoe in Shoes) { inventory+=$"#{i++}: {shoe.Description}\n"; }

            return inventory;
        }

        public void AddShoe(Shoe shoe)
        {
            Shoes.Add(shoe);
        }

        public void RemoveShoe(int shoe)
        {
            Shoes.RemoveAt(shoe);
        }
        public void RemoveShoe(Shoe shoe)
        {
            Shoes.Remove(shoe);
        }


    }
}