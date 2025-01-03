// LinkedIn Learning Course .NET Programming with C# by Joe Marini
// Reading and Writing data from and to files

// Make sure the example file exists
const string filename = "TestFile.txt";

// TODO 1: WriteAllText overwrites a file with the given content
// if (!File.Exists(filename)) {
    File.WriteAllText(filename, "This content replaces everything in a TXT file.");
// }

// TODO 3: AppendAllText adds text to an existing file
File.AppendAllText(filename, " This text is appended to the file.");

// TODO 4: A FileStream can be opened and written to until closed
using (StreamWriter sw = File.AppendText(filename)) 
{
    sw.WriteLine();
    sw.WriteLine("line 1");
    sw.WriteLine("line 2");
    sw.WriteLine("line 3");
}

// TODO 2: ReadAllText reads all the content from a file
Console.WriteLine(File.ReadAllText(filename));
