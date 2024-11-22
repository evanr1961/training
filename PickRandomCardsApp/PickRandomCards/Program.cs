using System;
using System.Collections.Generic;
using System.Text;

namespace PickRandomCards
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.Write("Enter Number of Cards: ");
            string? line = Console.ReadLine();

            if (line != null && int.TryParse(line, out int numberOfCards))
            {
                foreach (string card in CardPicker.PickSomeCards(numberOfCards))
                {
                    Console.WriteLine(card);
                }
            }
        }
    }
}