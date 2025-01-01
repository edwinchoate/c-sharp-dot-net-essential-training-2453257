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

---
End of document
