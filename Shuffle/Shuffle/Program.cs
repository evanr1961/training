internal class Program
{
    private static void Main(string[] args)
    {
        int[] Deck = new int[52];
        

        for (int i = 0; i < Deck.Length; i++) { Deck[i] = i+1; }

        Shuffle(Deck);
    
        for (int i = 0;i < Deck.Length; i++)
        {
            Console.WriteLine($" {i,2}: {Deck[i],2}");
        }
    }

    static void Shuffle(int[] ordered)
    {
        Random random = new Random();

        for (int i = ordered.Length-1; i >= 0; i--)
        {
            int swap = random.Next(ordered.Length);
            int temp = ordered[swap];
            ordered[swap] = ordered[i];
            ordered[i] = temp;
        }
        return;
    }
}