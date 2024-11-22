using System.Collections.Generic;
using static Program;

internal class Program
{
    private static void Main(string[] args)
    {
        List<Duck> ducks = new List<Duck>()
        {
            new Duck() { Kind = KindOfDuck.Mallard, Size = 17 },
            new Duck() { Kind = KindOfDuck.Muscovy, Size = 18 },
            new Duck() { Kind = KindOfDuck.Loon, Size = 14 },
            new Duck() { Kind = KindOfDuck.Muscovy, Size = 11 },
            new Duck() { Kind = KindOfDuck.Mallard, Size = 14 },
            new Duck() { Kind = KindOfDuck.Loon, Size = 13 },
        };

        DuckComparer comparer = new DuckComparer();
        comparer.SortBy = SortCriteria.KindThenSize;
        ducks.Sort(comparer);
        PrintDucks(ducks);
    }

    private static void PrintDucks(List<Duck> ducks)
    {
        foreach (Duck duck in ducks)
        {
            Console.WriteLine(duck);
        }
    }
    public class Duck : IComparable<Duck>
    {
        public int Size { get; set; }

        public KindOfDuck Kind {  get; set; }

        public int CompareTo(Duck duckToCompare)
        {
            if (this.Size > duckToCompare.Size) return 1;
            else if ( this.Size < duckToCompare.Size) return -1; 
            else return 0;
        }

        public override string ToString()
        {
             return $"{this.Size} inch {this.Kind}";
        }
    }

    public enum KindOfDuck
    {
        Mallard,
        Muscovy,
        Loon,
    }

    public enum SortCriteria
    {
        SizeThenKind,
        KindThenSize,
    }
    public class DuckComparer : IComparer<Duck>
    {
        public SortCriteria SortBy = SortCriteria.SizeThenKind;
        public int Compare(Duck duck1, Duck duck2)
        {
            if (SortBy == SortCriteria.SizeThenKind)
            {
                if (duck1.Size > duck2.Size) return 1;
                else if (duck1.Size < duck2.Size) return -1;
                else
                {
                    if (duck1.Kind > duck2.Kind) return 1;
                    else if (duck1.Kind < duck2.Kind) return -1;
                    else return 0;
                }
            }
            else
            {
                if (duck1.Kind > duck2.Kind) return 1;
                else if (duck1.Kind < duck2.Kind) return -1;
                else
                {
                    if (duck1.Size > duck2.Size) return 1;
                    else if (duck1.Size<duck2.Size) return -1;
                    else return 0;
                }
            }
        }
    }
}