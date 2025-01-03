using System.Globalization;

// LinkedIn Learning Course .NET Programming with C# by Joe Marini
// Example file for formatting date information

// Define a date
DateTime AprFools = new DateTime(2025, 4, 1, 13, 23, 30);

// TODO: 'd' Short date: mm/dd/yyyy (or dd/mm depending on locale)
// TODO: 'D' Full date: mm/dd/yyyy (or dd/mm depending on locale)
// TODO: 'f' Full date, short time
// TODO: 'F' Full date, long time
// TODO: 'g' General date and time
// TODO: 'G' General date and time

object[] printjob1 = {
    $"{AprFools:d}", $"{AprFools:D}", $"{AprFools:f}", $"{AprFools:F}", $"{AprFools:g}", $"{AprFools:G}"
};
Array.ForEach(printjob1, Console.WriteLine);


// TODO: Format using a specific CultureInfo
string germanDate = AprFools.ToString("d", CultureInfo.CreateSpecificCulture("de-DE"));

// TODO: Defining custom date and time formats
string custom1 = $"{AprFools:dddd -- MMMM d, yyyy}";
string custom2 = $"{AprFools:ddd h:mm:ss tt}";
string custom3 = $"{AprFools:MMM d yyyy}";

object[] printjob2 = { germanDate, custom1, custom2, custom3 };
Array.ForEach(printjob2, Console.WriteLine);
