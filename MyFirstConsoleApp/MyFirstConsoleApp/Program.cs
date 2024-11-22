using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TryAnif();
            TrySomeLoops();
            TryAnIfElse();

            Console.ReadLine();
        }

        private static void TryAnIfElse()
        {
            int count = 0;

            while (count < 10)
            {
                count = count + 1;
            }

            for (int i = 0; i < 5; i++) 
            {
                count = count - 1;
            }

            Console.WriteLine("The  answer is " + count);
        }

        private static void TrySomeLoops()
        {
            int x = 5;
            if ( x== 10)
            {
                Console.WriteLine("x must be 10");
            }
            else
            {
                Console.WriteLine("x isn't 10");
            }
        }

        private static void TryAnif()
        {
            int someValue = 4;
            string name = "Bobbo Jr.";
            if (( someValue == 3) && (name == "joe"))
            {
                Console.WriteLine("x is 3 and name is Joe");
            }
            Console.WriteLine("this line runs no m atter what");
        }
    }
}