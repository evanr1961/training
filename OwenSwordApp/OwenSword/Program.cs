using System.Security.Principal;

internal class Program
{
    private static void Main(string[] args)
    {
        SwordDamage sword = new();
        Random r = new();
        while (true)
        {
            Console.Write("0 for no magic/flaming, 1 for magic, 2 for flaming, 3 for both, anything else to quit:");
            char key = Console.ReadKey(false).KeyChar;

            if (key != '0' && key != '1' && key != '2' && key != '3' ) { return; }

            int roll = r.Next(1, 7) + r.Next(1, 7) + r.Next(1, 7);
            sword.Damage = roll;
            sword.SetMagic(key == '1' || key == '3');
            sword.SetFlaming(key == '2' || key == '3');

            Console.WriteLine("\nRolled " + roll + " for " + sword.Damage + " HP\n");
        }
    }
}
class SwordDamage
{
    public const int BASE_DAMAGE = 3;
    public const int FLAME_DAMAGE = 2;

    public int Roll;
    public Decimal MagicMultiplier = 1M;
    public int FlamingDamage = 0;
    public int Damage;

    public void CalculateDamage()
    {
        Damage = (int)(Roll * MagicMultiplier) + BASE_DAMAGE + FlamingDamage;
    }

    public void SetMagic(bool isMagic)
    {
        if (isMagic)
        {
            MagicMultiplier = 1.75M;
        }
        else
        {
            MagicMultiplier = 1M;
        }
        CalculateDamage();
    }

    public void SetFlaming(bool isFlaming)
    {
        if (isFlaming)
        {
            Damage += FLAME_DAMAGE;
        }
    }
}