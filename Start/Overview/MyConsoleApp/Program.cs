

Console.WriteLine("What's your name?");

string name = Console.ReadLine() ?? "";

Console.WriteLine($"Hello, {name}!");

Console.WriteLine(Environment.OSVersion.Platform);
Console.WriteLine(Environment.OSVersion.VersionString);