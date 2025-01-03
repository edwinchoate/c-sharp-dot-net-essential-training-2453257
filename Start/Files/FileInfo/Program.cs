// LinkedIn Learning Course .NET Programming with C# by Joe Marini
// Working with file information

// Make sure the example file exists
const string filename = "TestFile.txt";

if (!File.Exists(filename)) {
    using (StreamWriter sw = File.CreateText(filename)) {
        sw.WriteLine("This is a text file.");
    }
}

// TODO: Get some information about the file
Console.WriteLine(File.GetCreationTime(filename));
Console.WriteLine(File.GetLastWriteTime(filename));
Console.WriteLine(File.GetLastAccessTime(filename));

Console.WriteLine(File.GetAttributes(filename));
// File.SetAttributes(filename, FileAttributes.ReadOnly);
// Console.WriteLine(File.GetAttributes(filename));

// TODO: We can also get general information using a FileInfo 
FileInfo fileInfo = new FileInfo(filename);

long fileLength = fileInfo.Length;
DirectoryInfo directory = fileInfo.Directory;
bool isReadOnly = fileInfo.IsReadOnly;

// TODO: File information can also be manipulated
File.SetCreationTime(filename, DateTime.Now);

Console.WriteLine(File.GetCreationTime(filename));