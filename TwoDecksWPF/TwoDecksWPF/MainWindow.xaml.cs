using System.Collections.ObjectModel;
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

namespace TwoDecksWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            if (Resources["rightDeck"] is Deck rightDeck)
            {
                rightDeck.Reset();
            }
        }

        private void MoveCard(bool leftToRight)
        {
            if ((Resources["rightDeck"] is Deck rightDeck) && (Resources["leftDeck"] is Deck leftDeck))
            {
                if (leftToRight)
                {
                    if (leftDeckListBox.SelectedItem is Card card)
                    {
                        leftDeck.Remove(card);
                        rightDeck.Add(card);
                    }
                }
                else
                {
                    if (rightDeckListBox.SelectedItem is Card card)
                    {
                        rightDeck.Remove(card);
                        leftDeck.Add(card);
                    }
                }
            }
        }

        private void ShuffleLeftDeck_Click(object sender, RoutedEventArgs e)
        {
            if (Resources["leftDeck"] is Deck leftDeck)
            {
                leftDeck.Shuffle();
            }
        }

        private void ResetLeftDeck_Click(object sender, RoutedEventArgs e)
        {
            if (Resources["leftDeck"] is Deck leftDeck)
            {
                leftDeck.Reset();
            }
        }

        private void ClearRightDeck_Click(object sender, RoutedEventArgs e)
        {
            if (Resources["rightDeck"] is Deck rightDeck)
            {
                rightDeck.Clear();
            }
        }

        private void SortRightDeck_Click(object sender, RoutedEventArgs e)
        {
            if (Resources["rightDeck"] is Deck rightDeck)
            {
                rightDeck.Sort();
            }
        }

        private void LeftDeckMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            MoveCard(true);
        }

        private void RightDeckMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            MoveCard(false);
        }

        private void LeftDeckKeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.Key == Key.Enter)
            {
                MoveCard(true);
            }

        }

        private void RightDeckKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                MoveCard(false);
            }
        }
    }
}