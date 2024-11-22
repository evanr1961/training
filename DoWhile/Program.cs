string[] myStrings = new string[2] { "I like pizza. I like roast chicken. I like salad", "I like all three of the menu choices" };

int periodLocation = 0;

foreach(string myString in myStrings)
{
    periodLocation = myString.IndexOf(".");

    string[] sentences = myString.Split(".");
    foreach(string sentence in sentences)
    {
        Console.WriteLine(sentence.Trim());
    }
}