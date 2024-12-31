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

---
End of document
