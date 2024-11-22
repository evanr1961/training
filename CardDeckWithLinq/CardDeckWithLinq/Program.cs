using CardGroupQuery;

internal class Program
{
    private static void Main(string[] args)
    {

        Deck deck = new Deck();

        var grouped = from card in deck
                      group card by card.Suit into suitGroup
                      orderby suitGroup.Key descending
                      select suitGroup;
        foreach (var group in grouped)
        {
            Console.WriteLine(group.Key);
        }

        Console.WriteLine("===========================");
        grouped = deck.GroupBy(card => card.Suit).OrderByDescending(group => group.Key);
        foreach (var group in grouped)
        {
            Console.WriteLine(group.Key);
        }

        Console.WriteLine("===========================");

        var processedCards = deck
            .Take(3).Concat(deck.TakeLast(3))
            .OrderByDescending(card => card)
            .Select(card => card.Value switch
            {
                Values.King => Output(card.Suit, 7),
                Values.Ace => $"It's an ace! {card.Suit}",
                Values.Jack => Output((Suits)card.Suit - 1, 9),
                Values.Two => Output(card.Suit, 18),
                _ => card.ToString(),
            });

        foreach(var output in processedCards)
        {
            Console.WriteLine(output);
        }
    }

    static string Output(Suits suits, int Number) =>
        $"Suit is {suits} and number is {Number}";
}