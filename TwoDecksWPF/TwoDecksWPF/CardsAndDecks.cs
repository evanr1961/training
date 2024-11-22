using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwoDecksWPF
{
    class CardCompareByValue : IComparer<Card>
    {
        public int Compare(Card? x, Card? y)
        {
            if (x == null || y == null) return 0;

            if (x.Suit > y.Suit) return -1;
            else if (x.Suit < y.Suit) return 1;
            else if (x.Value > y.Value) return -1;
            else if (x.Value < y.Value) return 1;
            else return 0;

        }
    }

    public class Card : IComparable<Card>
    {
        public int Value { get; set; }
        public int Suit { get; set; }

        public static readonly string[] Suits =
        {
            "Diamonds",
            "Clubs",
            "Hearts",
            "Spades",
        };

        public static readonly string[] Values =
        {
            "Zero",
            "Ace",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "Jack",
            "Queen",
            "King",
        };

        public Card(int suit, int value)
        {
            Suit = suit;
            Value = value;
        }

        public override string ToString()
        {
            return $"{Values[Value]} of {Suits[Suit]}";
        }

        public int CompareTo(Card? other)
        {
            if (other == null) return 0;
            if (other.Suit > this.Suit) return -1;
            else if (other.Suit < this.Suit) return 1;
            else
            {
                if (other.Value > this.Value) return -1;
                else if (other.Value < this.Value) return 1;
                else return 0;
            }

        }
    }

    public class Deck : ObservableCollection<Card>
    {
        private static Random random = new();

        public List<Card> Cards = new();

        public Deck() : base()
        {
            Reset();
        }

        public void Reset()
        {
            Cards.Clear();
            for (int suit = 0; suit < 4; suit++)
            {
                for (int value = 1; value < 14; value++)
                {
                    Cards.Add(new Card(suit, value));
                }
            }
        }

        public Card Deal(int index)
        {
            Card card = Cards[index];
            Cards.RemoveAt(index);
            return card;
        }

        public void Shuffle()
        {

            for (int i = Cards.Count - 1; i >= 0; i--)
            {
                int swap = random.Next(Cards.Count - 1);
                (Cards[i], Cards[swap]) = (Cards[swap], Cards[i]);
            }
        }

        public void Sort()
        {
            Cards.Sort();
        }
    }
}
