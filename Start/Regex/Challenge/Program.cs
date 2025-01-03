using System.Text.RegularExpressions;

namespace Challenge;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine(ReverseDate("11/12/2020"));
    }

    public static string ReverseDate (string date) 
    {
        Regex digits = new Regex("[0-9]+");

        MatchCollection matches = digits.Matches(date);

        return String.Join('-', new string[] { matches[2].ToString(), matches[0].ToString(), matches[1].ToString() });
    }
}
