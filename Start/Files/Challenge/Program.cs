namespace Challenge;

class Program
{
    static void Main(string[] args)
    {

        DirectoryInfo dir = new DirectoryInfo("FileCollection");

        FileInfo[] xlsxFiles = dir.GetFiles("*.xlsx");
        FileInfo[] docxFiles = dir.GetFiles("*.docx");
        FileInfo[] pptxFiles = dir.GetFiles("*.pptx");

        long xlsxBytes = CalcTotalBytes(xlsxFiles);
        long docxBytes = CalcTotalBytes(docxFiles);
        long pptxBytes = CalcTotalBytes(pptxFiles);

        var stats = new {
            FileCount = xlsxFiles.Length + docxFiles.Length + pptxFiles.Length,
            XlsCount = xlsxFiles.Length,
            DocCount = docxFiles.Length,
            PptCount = pptxFiles.Length,
            TotalSize = xlsxBytes + docxBytes + pptxBytes,
            XlsSize = xlsxBytes,
            DocSize = docxBytes,
            PptSize = pptxBytes,
        };

        using (StreamWriter sw = File.CreateText("results.txt")) 
        {
            sw.WriteLine(
                "~~~~ Results ~~~~\n" +
                $"Total Files: {stats.FileCount}\n" +
                $"Excel Count: {stats.XlsCount}\n" +
                $"Word Count: {stats.DocCount}\n" +
                $"PowerPoint Count: {stats.PptCount}\n" +
                "----\n" +
                $"Total Size: {stats.TotalSize:N0}\n" +
                $"Excel Size: {stats.XlsSize:N0}\n" +
                $"Word Size: {stats.DocSize:N0}\n" +
                $"PowerPoint Size: {stats.PptSize:N0}"
            );
        }
    }

    static long CalcTotalBytes (FileInfo[] files) 
    {
        long total = 0;
        foreach (FileInfo file in files) 
        {
            total += file.Length;
        }
        return total;
    }

}