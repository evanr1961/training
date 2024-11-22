using System.Collections.Generic;
using static System.Diagnostics.Activity;

internal class Program
{
    enum Sport { Football, Baseball, Basketball, Hockey, Boxing, Rugby, Fencing };
    private static void Main(string[] args)
    {
        var sports = new ManualSportSequence();
        
        foreach(var sport in sports)
        {
            Console.WriteLine(sport.ToString());
        }
    }

    class ManualSportSequence : IEnumerable<Sport>
    {
        public IEnumerator<Sport> GetEnumerator()
        {
            return new ManualSportEnumerator();
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    class ManualSportEnumerator : IEnumerator<Sport>
    {
        int current = -1;
        public Sport Current { get { return (Sport)current; } }
        public void Dispose() { return;  }
        object System.Collections.IEnumerator.Current { get {  return Current; } }
        public bool MoveNext()
        {
            var maxEnumValue = Enum.GetValues(typeof(Sport)).Length;
            if ((int) current >= maxEnumValue - 1) 
            { 
                return true;
            }
            current++;
            return true;
        }
        public void Reset() { current = 0; }
    };
}