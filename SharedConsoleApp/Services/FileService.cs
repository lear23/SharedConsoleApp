
using SharedConsoleApp.Interfaces;
using System.Diagnostics;

namespace SharedConsoleApp.Services;

internal class FileService : IFileService
{   

      public bool SaveContentToFile(string filePath, string content)
    {
        try
        {
            using var sw = new StreamWriter(filePath);
            sw.WriteLine(content);
        }
        catch (Exception ex) { Debug.WriteLine("FileService-saveFileToFile:: " + ex.Message); }
        return false;
    }
    public string GetContentFromList(string filePath)
    {


        try
        {
            if (File.Exists(filePath))
            {
                return File.ReadAllText(filePath);
            }
        }
        catch (Exception ex) { Debug.WriteLine("FileService-ReadFileFromFile:: " + ex.Message); }
        return null!;
    }
}
