// LinkedIn Learning Course .NET Programming with C# by Joe Marini
// Creating and Deleting Directories

const string dirname = "TestDir";

// TODO: Create a Directory if it doesn't already exist
if (Directory.Exists(dirname))
    Directory.Delete(dirname);

Directory.CreateDirectory(dirname);

// TODO: Get the path for the current directory
Console.WriteLine(Directory.GetCurrentDirectory());

// TODO: Just like with files, you can retrieve info about a directory
DirectoryInfo dirInfo = new DirectoryInfo(Directory.GetCurrentDirectory());

string name = dirInfo.Name;
DirectoryInfo parent = dirInfo.Parent;
DateTime creationTime = dirInfo.CreationTime;

// TODO: Enumerate the contents of directories
// Console.WriteLine("Just directories:");

var directories = new List<string>(Directory.EnumerateDirectories(Directory.GetCurrentDirectory()));

foreach (string dir in directories)
{
    Console.WriteLine(dir);
}

Console.WriteLine("---------------");

Console.WriteLine("Just files:");

var files = new List<string>(Directory.EnumerateFiles(Directory.GetCurrentDirectory()));

foreach (string file in files)
{
    Console.WriteLine(file);
}

Console.WriteLine("---------------");

Console.WriteLine("All directory contents:");

var everything = new List<string>(Directory.EnumerateFileSystemEntries(Directory.GetCurrentDirectory()));

foreach (var thing in everything)
{
    Console.WriteLine(thing);
}
