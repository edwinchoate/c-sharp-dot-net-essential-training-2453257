// LinkedIn Learning Course .NET Programming with C# by Joe Marini
// Example file for Replacing content with Regexes 
using System.Text.RegularExpressions;

string teststr1 = "The quick brown Fox jumps over the lazy Dog";

Regex CapWords = new Regex(@"[A-Z]\w+");

// TODO: Regular expressions can be used to replace content in strings
// in addition to just searching for content
string censored = CapWords.Replace(teststr1, "***");
Console.WriteLine(censored);

Console.WriteLine(CapWords.Replace("hello World", "!!!"));

// TODO: Replacement text can be generated on the fly using MatchEvaluator
// This is a delegate that computes the new value of the replacement

Regex capitalizedWords = new Regex(@"[A-Z]\w+");

Console.WriteLine(capitalizedWords.Replace("hello World", new MatchEvaluator(Leet)));

string Leet (Match match) 
{
    string leeted = "";
    foreach (char c in match.ToString()) 
    {
        if (c == 'o') leeted += '0';
        else if (c == 'l') leeted += '1';
        else leeted += c;
    }
    return leeted;
}