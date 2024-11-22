using System.ComponentModel.DataAnnotations;
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

namespace SwordDamage
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Random random = new();
        SwordDamageCalculator swordDamage = new();
        public MainWindow()
        {
            InitializeComponent();
            swordDamage.Magic = false;
            swordDamage.Flaming = false;
            //RollDice();
        }

        public void RollDice()
        {
            swordDamage.Roll = random.Next(1, 7) +
                               random.Next(1, 7) +
                               random.Next(1, 7);

            DisplayDamage();
        }

        void DisplayDamage()
        {
            if (swordDamage.Roll == 0)
            {
                damage.Text = "--No Roll--";
            }
            else
            {
                damage.Text = "Rolled " + swordDamage.Roll + " for " + swordDamage.Damage + " HP";
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RollDice();
        }

        private void Flaming_Checked(object sender, RoutedEventArgs e)
        {
            swordDamage.Flaming = true;
            DisplayDamage();
        }

        private void Flaming_Unchecked(object sender, RoutedEventArgs e)
        {
            swordDamage.Flaming = false;
            DisplayDamage();
        }

        private void Magic_Checked(object sender, RoutedEventArgs e)
        {
            swordDamage.Magic = true;
            DisplayDamage();
        }

        private void Magic_Unchecked(object sender, RoutedEventArgs e)
        {
            swordDamage.Magic = false;
            DisplayDamage();
        }
    }
}