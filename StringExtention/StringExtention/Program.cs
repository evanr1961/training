namespace AmazingExtensions
{

    public static class ExtendAHuman
    {
        public static bool IsDistressCall(this string s)
        {
            return ( s.Contains("Help!")) ? true : false;
        }
    }
internal class Program
{
    private static void Main(string[] args)
    {
            string message = "Evil clones are wreaking havoc. Help!";
            Console.WriteLine((message.IsDistressCall()) ? "Calling Captin Amazing" : "Snoring, Snoring, Snort");
       
    }
}


}

