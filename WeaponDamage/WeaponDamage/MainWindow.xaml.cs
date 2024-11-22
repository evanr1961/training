using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace WeaponDamage
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Random random = new Random();
        
        public MainWindow()
        {
            InitializeComponent();

            SwordDamage swordDamage = new SwordDamage(RollDice());
            ArrowDamage arrowDamage = new ArrowDamage(RollDice());

            swordDamage.Magic = false;
            swordDamage.Flaming = false;

            arrowDamage.Magic = false;
            arrowDamage.Flaming = false;
            //RollDice();
        }

        public int RollDice()
        {
            int roll = random.Next(1, 7) +
                            random.Next(1, 7) +
                               random.Next(1, 7);

            return roll;
        }

        void DisplayDamage(WeaponDamage weaponDamage )
        {
            if (weaponDamage.Roll == 0)
            {
                damage.Text = "--No Roll--";
            }
            else
            {
                damage.Text = "Rolled " + weaponDamage.Roll + " for " + weaponDamage.Damage + " HP";
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RollDice();
        }

        private void Flaming_Checked(object sender, RoutedEventArgs e)
        {
            weaponDamage.Flaming = true;
            DisplayDamage();
        }

        private void Flaming_Unchecked(object sender, RoutedEventArgs e)
        {
            weaponDamage.Flaming = false;
            DisplayDamage();
        }

        private void Magic_Checked(object sender, RoutedEventArgs e)
        {
            weaponDamage.Magic = true;
            DisplayDamage();
        }

        private void Magic_Unchecked(object sender, RoutedEventArgs e)
        {
            weaponDamage.Magic = false;
            DisplayDamage();
        }
    }
    public class WeaponDamage
    {
        public int Damage { get; protected set; }
        private int roll;
        public int Roll {  
            get { return roll; }
            set { roll = value;
                CalculateDamage();
            } 
        }
        private bool magic;
        public bool Magic { 
            get { return magic; } 
            set { magic = value;
                CalculateDamage();
            } 
        }

        private bool flaming;
        public bool Flaming { 
            get { return flaming; } 
            set { flaming = value;
                CalculateDamage();
            } 
        }
                
        protected virtual void CalculateDamage() {/* subclass provides implementation */ }

        public WeaponDamage(int startingRoll)
        {
            roll = startingRoll;
            CalculateDamage();

        }

    }

    public class SwordDamage : WeaponDamage 
    {
        public const int BASE_DAMAGE = 3;
        public const int FLAME_DAMAGE = 2;

        public SwordDamage(int startingRoll) : base(startingRoll) { }
        protected override void CalculateDamage()
        {
            decimal magicMultiplier = 1M;
            if (Magic) magicMultiplier = 1.75M;

            Damage = BASE_DAMAGE;
            Damage = (int)(Roll * magicMultiplier) + BASE_DAMAGE;

            if (Flaming) Damage += FLAME_DAMAGE;
        }
    }

    public class ArrowDamage : WeaponDamage
    {
        private const decimal BASE_MULTIPLIER = 0.35M;
        private const decimal MAGIC_MULTIPLIER = 2.5M;
        private const decimal FLAME_DAMAGE = 1.25M;

        public ArrowDamage(int startingRoll) : base(startingRoll) { }
        protected override void CalculateDamage() 
        {
            decimal baseDamage = Roll * BASE_MULTIPLIER;
            if (Magic) baseDamage *= MAGIC_MULTIPLIER;
            if (!Flaming) Damage = (int)Math.Ceiling(baseDamage + FLAME_DAMAGE);
            else Damage = (int)Math.Ceiling(baseDamage);
        }
    }
}