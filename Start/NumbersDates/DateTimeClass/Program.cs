// LinkedIn Learning Course .NET Programming with C# by Joe Marini
// Example file for working with Dates and Times

// TODO: Use DateTime.Now property to get the current date and time
DateTime now = DateTime.Now;

// TODO: DateTime.Today gets just the current date with time set to 12:00:00 AM
DateTime today = DateTime.Today;

// TODO: DateOnly and TimeOnly represent just dates and times
DateOnly date = DateOnly.FromDateTime(DateTime.Now);
TimeOnly time = TimeOnly.FromDateTime(DateTime.Now);

// TODO: Dates have properties that can be inspected
var dayOfWeek = today.DayOfWeek;
var dayOfYear = today.DayOfYear;

// TODO: Dates also have methods to change their values
DateTime datetime = DateTime.Now;
datetime = datetime.AddDays(5);
datetime = datetime.AddHours(5);

// TODO: The TimeSpan class represents a duration of time
DateTime aprilFools = new DateTime(now.Year, 4, 1);
DateTime newYears = new DateTime(now.Year, 1, 1);

TimeSpan interval = newYears - aprilFools;

// TODO: Dates can be compared using regular operators
bool isNewYearsPrior = newYears < aprilFools;


object[] printjob = {
    now, today, date, time, dayOfWeek, dayOfYear, datetime, aprilFools, newYears, interval, isNewYearsPrior
};
Array.ForEach(printjob, Console.WriteLine);