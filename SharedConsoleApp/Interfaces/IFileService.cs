

namespace SharedConsoleApp.Interfaces;

public interface IFileService 
{

    /// <summary>
    /// Save content to a specificed filedpath.
    /// </summary>
    /// <param name="filePath">enter the filepath with extension (eg: c:\project\myFyle.json)</param>
    /// <param name="content">enter your content as a string</param>
    /// <returns>return true if saved, false if failedl</returns>

    bool SaveContentToFile(string filePath, string content);


    /// <summary>
    /// Get content as string from a specified filepath
    /// </summary>
    /// <param name="filePath">enter the filepath with extension (eg: c:\project\myFyle.json)</param>
    /// <returns>returns file content as string if file exists, else return null </returns>


    string GetContentFromList(string filePath);
}
