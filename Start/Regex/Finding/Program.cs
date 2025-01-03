// LinkedIn Learning Course .NET Programming with C# by Joe Marini
// Example file for using Regex to find patterns
using System.Text.RegularExpressions;

string teststr1 = "The quick brown Fox jumps over the lazy Dog";
string teststr2 = "the quick brown fox jumps over the lazy dog";

// TODO: The IsMatch function is used to determine if the content of a string
// results in a match with the given Regex
Regex capitalizedWords = new Regex(@"[A-Z]\w+");

Console.WriteLine(capitalizedWords.IsMatch(teststr1));
Console.WriteLine(capitalizedWords.IsMatch(teststr2));

// TODO: The RegexOptions argument can be used to perform
// case-insensitive searches
Regex fox = new Regex("fox", RegexOptions.IgnoreCase);

Console.WriteLine(fox.IsMatch(teststr1));
Console.WriteLine(fox.IsMatch(teststr2));

// Use the Match and Matches methods to get information about
// specific Regex matches for a given pattern

// TODO: The Match method returns a single match at a time
Match match = capitalizedWords.Match("The quick Brown fox Jumps over The Lazy dog.");

while (match.Success)
{
    Console.Write($"{match.Value} ");
    match = match.NextMatch();
} // The Brown Jumps The Lazy
Console.WriteLine();

// TODO: The Matches method returns a collection of Match objects
MatchCollection matches = capitalizedWords.Matches("The quick Brown fox Jumps over The Lazy dog.");

foreach (Match word in matches) 
{
    Console.Write($"{word} ");
}
Console.WriteLine();
