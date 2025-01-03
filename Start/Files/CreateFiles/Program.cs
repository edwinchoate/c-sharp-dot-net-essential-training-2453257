// LinkedIn Learning Course .NET Programming with C# by Joe Marini
// Creating and Deleting Files

const string filename = "TestFile.txt";

// TODO: Create a new file - this will overwrite any existing file
// Use the "using" construct to automatically close the file stream

// TODO: Determine if a file exists
if (File.Exists(filename))
{
    File.Delete(filename);
}
using (StreamWriter sw = File.CreateText(filename)) 
{
    sw.WriteLine("This is content in the text file.");
}