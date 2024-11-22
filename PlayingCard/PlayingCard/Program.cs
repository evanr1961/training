using PlayingCard;
using System.Runtime.CompilerServices;

internal class Program
{
    private static void Main(string[] args)
    {
        Random random = new Random();
        int numberbetween0and3 = random.Next(4);
        int numberbetween1and13 = random.Next(1, 14);
        int anyRandomInteger = random.Next();

       // Card card = new Card((Suits) numberbetween0and3, (Values) numberbetween1and13);
        //Console.WriteLine(card.Name);

        Deck deck = new Deck();

        deck.PrintCards();
        

    }

    public class Deck
    {
        private readonly Card[] cards = new Card[52];
        public Deck() { 
            int index = 0;
            for (int suit = 0; suit <= 3; suit++)
            {
                for (int value = 1;  value <= 13; value++)
                {
                    cards[index++] = new Card((Suits)suit,(Values)value);
                }
            }
        }

        public void PrintCards()
        {
            for(int i = 0; i < 52; i++)
            {
                Console.WriteLine(cards[i].Name);
            }
        }
    }
    public class Card
    {
        

        public Values Value { get; set; }
        public Suits Suit { get; set; }
        public string Name { get { return $"{Value} of {Suit}"; } }

        public override string ToString() { return Name; }

        public Card(Suits suit,Values value)
        {
            Value = value;
            Suit = suit;
        }
    }
}