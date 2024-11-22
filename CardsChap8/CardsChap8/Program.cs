using System.Security.Cryptography.X509Certificates;

internal class Program
{
    private static void Main(string[] args)
    {
        Deck deck = new Deck();
        Console.WriteLine("=====================================================");
        Console.WriteLine("|     Initial State                 Initial State   |");
        Console.WriteLine("=====================================================");
        int i = 0;
        foreach(Card card in deck.Cards)
        {
            Console.WriteLine($"{i++}: {card}");
        }
        Console.WriteLine("=====================================================");
        Console.WriteLine("|     Shuffled State                 Shuffled State  |");
        Console.WriteLine("=====================================================");
        deck.Shuffle();
        i = 0;
        foreach (Card card in deck.Cards)
        {
            Console.WriteLine($"{i++}: {card}");
        }
        Console.WriteLine("=====================================================");
        Console.WriteLine("|     Sorted State                     Sorted State  |");
        Console.WriteLine("=====================================================");
        deck.Sort();
        i = 0;
        foreach (Card card in deck.Cards)
        {
            Console.WriteLine($"{i++}: {card}");
        }
    }

    public static readonly string[] Suits = {
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
        "King"
    };

    class CardCompareByValue : IComparer<Card>
    {
        public int Compare(Card? x, Card? y)
        {
            throw new NotImplementedException();
        }
    }

    public class Card : IComparable<Card>
    {
        int Value { get; set; }
        int Suit { get; set; }

        public Card(int suit, int value)
        {
            Suit = suit;
            Value = value;
        }

        public override string ToString()
        {
            return $"{Values[Value]} of {Suits[Suit]}";
        }

        public int CompareTo(Card other)
        {
            if(other == null) return 0 ;
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

    public class Deck
    {
        public List<Card> Cards = new();

        public Deck()
        {
            for(int suit = 0; suit < 4; suit++)
            {
                for ( int value = 1; value < 14; value++)
                {
                    Cards.Add(new Card(suit, value));
                }
            }
        }

        public void Shuffle()
        {
            Random random = new Random();

            for(int i = Cards.Count-1; i >=0 ; i--)
            {
                int swap = random.Next(Cards.Count - 1);
                Card temp = Cards[swap];
                Cards[swap] = Cards[i];
                Cards[i] = temp;
            }
        }

        public void Sort()
        {
          Cards.Sort();
        }
    }
}