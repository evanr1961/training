using Damage;
using SwordDamage;

internal class Program
{
    static Random random = new Random();

    private static void Main(string[] args)
    {
        SwordDamageCalculator sword = new();
        ArrowDamageCalculator arrow = new();

        while (true)
        {
                
            Console.Write("0 for no magic/flaming, 1 for magic, 2 for flaming, 3 for both, anything else to quit: ");
            char key = Console.ReadKey(false).KeyChar;
            if (key != '0' && key != '1' && key != '2' && key != '3') { return; }

            Console.WriteLine("\nS for sword, A for arrow, anything else to quit: ");
            char weaponKey = Char.ToUpper(Console.ReadKey().KeyChar);
            switch (weaponKey)
            {
                case 'S':
                    sword.Roll = RollDice(3);
                    sword.Magic = ( key == 1 || key == 3 );
                    sword.Flaming = ( key == 2 || key == 3 );
                    Console.WriteLine($"\nRolled {sword.Roll} for {sword.Damage} HP\n");
                    break;
                case 'A':
                    arrow.Roll = RollDice(3);
                    arrow.Magic = (key == 1 || key == 3);
                    arrow.Flaming = (key == 2 || key == 3);
                    Console.WriteLine($"\nRolled {arrow.Roll} for {arrow.Damage} HP\n");
                    break;
                default:
                    return;
            }

        }


    }
    private static int RollDice( int numberOfRolls)
    {
        int total = 0;
        for (int i = 0; i < numberOfRolls; i++) { total += random.Next(1, 7); }
        return total;
    }
}