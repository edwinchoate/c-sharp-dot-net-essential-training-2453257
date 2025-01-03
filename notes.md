# Notes

> .NET is essentially a runtime layer between your apps and the operating systems they run on

See all the .NET versions on your computer

```shell
$ dotnet --list-sdks
```

Create a new console app from the command line:

```shell
$ dotnet new console -n MyConsoleApp -f "net9.0" --use-program-main
```

* All of the above flags are optional

_Implicit usings_

.NET 6 is the first version to use the Implicit usings, which automatically include the following classes without you having to write any `using` statements:

* `System`
* `System.IO`
* `System.Collections.Generic`
* `System.Linq`
* `System.Net.Http`
* `System.Threading`
* `System.Threading.Tasks`

The [Environment class](https://learn.microsoft.com/en-us/dotnet/api/system.environment?view=net-9.0#properties) gives you access to information about the device/platform. 

The `default` keyword represents the default value for a given data type:

```C#
int i = default;  // i = 0
bool b = default; // b = False
```

C# has implicit type conversion. Ex: if you concat an int and a char together the char is converted to its numerical ASCII value. 

Defining a `struct`: 

```C#
struct MyStruct
{
    public int a;
    public bool b;
}
```

* You'd use `struct`s when dealing with small, lightweight data types that represent a single value or concept, and when you want to avoid the overhead associated with classes

_Passed by copy_ - When value types such as `int` or `struct` are passed into a function, .NET creates a copy of the variable and modifications to the variable inside of the function do not affect the variable outside of the function. 

_Passed by reference_ - When reference types such as `object` are passed into a function, .NET maintains a reference to the original variable. Modifications to the variable inside of the function also affect the variable outside of the function. Other reference types include: `string`, `class`, `record`

`System.GC` lets you interact with the .NET garbage collector.

Lookup the # of bytes allocated by the program: 

```C#
long bytes = GC.GetTotalMemory(false);
```

Manually call the garbage collector:

```C#
GC.Collect();
```

* Mainly for testing purposes

## Ch. 2 Working with Strings

Topics covered: 

* String interpolation
* String formatting 
* String manipulation
    * `String.Concat`
    * `String.Join`
    * `String.Equals`
    * `String.Compare`
    * `String.Replace`
* String searching
    * `String.Contains`
    * `String.StartsWith`
    * `String.EndsWith`
    * `String.IndexOf`
    * `String.LastIndexOf`
    * `String.IsNullOrEmpty`

You can pad values by adding a comma and a number after the variable in an interpolated string. A negative number makes the variable's value left-aligned within the alloted space, a positive number makes the variable's value right-aligned within the alloted space.

```C#
Console.WriteLine($"{"Column1", -12} | {"Column2", 12}");
Console.WriteLine($"{3, -12} | {5, 12}");

// Output:
// Column1      |      Column2
// 3            |            5
```

You can do the same thing as above but with format strings:

```C#
Console.WriteLine("{0, -12} | {1, 12}", "Column1", "Column2");
Console.WriteLine("{0, -12} | {1, 12}", 3, 5);
```

## Ch. 3 Using Numbers and Dates

Topics covered:

* Parse
    * `int.Parse`
    * `float.Parse`
    * `FormatException` - if a number can't be parsed
    * `int.TryParse`
    * `float.TryParse`
* Format strings (ex: `$"{someVar:D}"`)
    * `:D` - decimal
    * `:N` - number 
    * `:G` - general 
    * `:F` - fixed-point
    * `:E` - exponential
    * `:P` - percent
    * `:X` - hexidecimal
    * `:C` - currency
    * with precision (ex: `$"{someVar:D6}"` is a decimal with six digits of precision)
    * with padding and precision (ex: `$"{someVar,12:D6}"` is a decimal with 12 spaces of padding and six digits of precision)
* `DateTime` class
    * `AddDays(int)`, `AddHours(int)`, etc.
    * `TimeSpan` type
    * `DateOnly` type
    * `TimeOnly` type
* Formatting DateTimes (ex: `$"{someDateTime:d}"`)
    * `:d` - 4/1/2025
    * `:D` - Tuesday, April 1, 2025
    * `:f` - Tuesday, April 1, 2025 1:23PM
    * `:F` - Tuesday, April 1, 2025 1:23:30PM
    * `:g` - 4/1/2025 1:23PM
    * `:G` - 4/1/2025 1:23:30PM
    * `CultureInfo.CreateSpecificCulture(string)`
    * Custom formatting 
        * `$"{someDateTime:dddd -- MMMM d, yyyy}"` Tuesday -- April 1, 2025
        * `$"{AprFools:ddd h:mm:ss tt}"` Tue 1:23:30 PM
        * `$"{AprFools:MMM d yyyy}"` Apr 1 2025
* `DateTime.TryParse(string, out DateTime)`

## Ch. 4 Working with Files 

Create a text file and write content to it:

```C#
using (StreamWriter sw = File.CreateText("hello.txt")) 
{
    sw.WriteLine("Hello world!");
}
```

Delete a file:

```C#
string filename = "hello.txt";

if (File.Exists(filename))
    File.Delete(filename);
```

Over-write all of the content of a text file:

```C#
File.WriteAllText("hello.txt", "This content replaces all of content that was previously in hello.txt");
```

Read all of the text from a text file: 

```C#
string text = File.ReadAllText("hello.txt");
```

Append text to a file:

```C#
using (StreamWriter sw = File.Append("hello.txt")) 
{
    sw.WriteLine("This line is added to the end of the file.");
}
```

Accessing File metadata

* `File.GetCreationTime`
    * `File.SetCreationTime`
* `File.GetLastWriteTime`
    * `File.SetLastWriteTime`
* `File.GetLastAccessTime`
    * `File.SetLastAccessTime`

Set a file to read-only:

```C#
File.SetAttributes("hello.txt", FileAttributes.ReadOnly);
```

Get file info with the `FileInfo` class:

```C#
FileInfo fileInfo = new FileInfo("hello.txt");

long fileLength = fileInfo.Length;
DirectoryInfo directory = fileInfo.Directory;
bool isReadOnly = fileInfo.IsReadOnly;
```

Create a directory:

```C#
string dirname = "my-folder";

if (!Directory.Exists(dirname))
    Directory.CreateDirectory(dirname);
```

Delete a directory:

```C#
string dirname = "my-folder";

if (Directory.Exists(dirname))
    Directory.Delete(dirname);
```

Get directory info:

```C#
DirectoryInfo dirInfo = new DirectoryInfo(Directory.GetCurrentDirectory());

string name = dirInfo.Name;
DirectoryInfo parent = dirInfo.Parent;
DateTime creationTime = dirInfo.CreationTime;
```

Get the contents of a specified directory:

```C#
var directories = new List<string>(Directory.EnumerateDirectories(Directory.GetCurrentDirectory()));

var files = new List<string>(Directory.EnumerateFiles(Directory.GetCurrentDirectory()));

var everything = new List<string>(Directory.EnumerateFileSystemEntries(Directory.GetCurrentDirectory()));
```

## Regular Expressions

`System.Text.RegularExpressions`

Creating a regex object

```C#
using System.Text.RegularExpressions;

Regex capitalizedWords = new Regex(@"[A-Z]\w+");
```

Ignore case with `RegexOptions`:

```C#
Regex regex = new Regex("abc", RegexOptions.IgnoreCase);
```

Test to see if a given string would be a match for a given regex pattern:

```C#
Regex capitalizedWords = new Regex(@"[A-Z]\w+");

Console.WriteLine(capitalizedWords.IsMatch("hello"));  // --> False
Console.WriteLine(capitalizedWords.IsMatch("Hello")); // --> True
```

Iterate through each match one at a time:

```C#
Regex capitalizedWords = new Regex(@"[A-Z]\w+");

Match match = capitalizedWords.Match("The quick Brown fox Jumps over The Lazy dog.");
// .Match returns the first match found

while (match.Success)
{
    Console.Write($"{match.Value} ");
    match = match.NextMatch();
} 
// The Brown Jumps The Lazy
```

Get all matches: 

```C#
Regex capitalizedWords = new Regex(@"[A-Z]\w+");

MatchCollection matches = capitalizedWords.Matches("The quick Brown fox Jumps over The Lazy dog.");

foreach (Match match in matches) 
{...}
```

A simple find and replace: 

```C#
Regex capitalizedWords = new Regex(@"[A-Z]\w+");

Console.WriteLine(capitalizedWords.Replace("hello World", "!!!"));
// hello !!!
```

Find and replace with a function:

```C#
Regex capitalizedWords = new Regex(@"[A-Z]\w+");

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

Console.WriteLine(capitalizedWords.Replace("hello World", new MatchEvaluator(Leet)));
// hello W0r1d
```

---
End of document
