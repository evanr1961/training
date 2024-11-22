using System;
using System.Collections.Generic;
using System.Text;

namespace CardGroupQuery
{
    /* 
     * NOTE: If you did the Blazor version of the "Two Decks" project, your Deck
     * class will extend List<Card> and not ObservableCollection<Card>
     */

    using System.Collections.ObjectModel;
    using System.Xml.Linq;

    class Deck : ObservableCollection<Card>
    {
        private static Random random = new Random();

        public Deck()
        {
            Reset();
        }

        public Card Deal(int index)
        {
            Card cardToDeal = base[index];
            RemoveAt(index);
            return cardToDeal;
        }

        public void Reset()
        {
            Clear();
            for (int suit = 0; suit <= 3; suit++)
                for (int value = 1; value <= 13; value++)
                    Add(new Card((Values)value, (Suits)suit));
        }

        public Deck(string FileName)
        {
            using(var sr= new StreamReader(FileName))
            {
                var nextCard = sr.ReadLine();
                var cardParts = nextCard.Split(new char[] { ' ' });
                var suit = cardParts[2] switch
                {
                    "Diamonds" => Suits.Diamonds,
                    "Spades" => Suits.Spades,
                    "Hearts" => Suits.Hearts,
                    "Clubs" => Suits.Clubs,
                    _ => throw new Exception()
                };
                var value = cardParts[0] switch
                {
                    "Ace" => Values.Ace,
                    "2" => Values.Two,
                    "3" => Values.Three,
                    "4" => Values.Four,
                    "5" => Values.Five,
                    "6" => Values.Six,
                    "7" => Values.Seven,
                    "8" => Values.Eight,
                    "9" => Values.Nine,
                    "10" => Values.Ten,
                    "Jack" => Values.Jack,
                    "Queen" => Values.Queen,
                    "King" => Values.King,
                    _ => throw new Exception()
                };
            }
        }
        public bool WriteCards(string FileName)
        {
            try
            {
                using (var sw = new StreamWriter(FileName))
                {
                    foreach (Card card in this)
                    {
                        sw.WriteLine(card);
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
        public Deck Shuffle()
        {
            List<Card> copy = new List<Card>(this);
            Clear();
            while (copy.Count > 0)
            {
                int index = random.Next(copy.Count);
                Card card = copy[index];
                copy.RemoveAt(index);
                Add(card);
            }

            return this;
        }

        public void Sort()
        {
            List<Card> sortedCards = new List<Card>(this);
            sortedCards.Sort(new CardComparerByValue());
            Clear();
            foreach (Card card in sortedCards)
            {
                Add(card);
            }
        }
    }
}