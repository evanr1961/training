﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickACardUI
{
    class CardPicker
    {
        
        static Random random = new Random();
        public static string[] PickSomeCards(int numberOfCards)
        {
            RandomDoubles();

            string[] pickedCards = new string[numberOfCards];
            for (int i = 0; i < numberOfCards; i++)
            {
                pickedCards[i] = RandomValue() + " of " + RandomSuit();
            }
            return pickedCards;
        }

        private static string RandomSuit()
        {
         
            int value = random.Next(1, 5);
         
            if (value == 1) return "Spades";
            if (value == 2) return "Hearts";
            if (value == 3) return "Clubs";
            return "Diamonds";
        }

        private static string RandomValue()
        {
            int value = random.Next(1, 14);
            if (value == 1) return "Ace";
            if (value == 11) return "Jack";
            if (value == 12) return "Queen";
            if (value == 13) return "King";
            return value.ToString();
        }

        private static void RandomDoubles()
        {
            Random random = new();
            double[] randomdoubles = new();
            for (int i = 0; i < 20; i++)
            {
                double value = random.NextDouble();
                randomdoubles[i] = value;
            }
    }
}
