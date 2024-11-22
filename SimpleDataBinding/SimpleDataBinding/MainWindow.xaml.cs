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

namespace SimpleDataBinding
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Primary.Text = "In the Beginning";
            Secondary.Text = "After the End";
        }

        public class BackingStore
        {
            public string First;
            public string Second;
            public BackingStore()
            {
                First = "Constructor1";
                Second = "Constructor2";
            }
        }
    }
}