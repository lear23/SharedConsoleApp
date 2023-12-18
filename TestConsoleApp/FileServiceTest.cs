

using SharedConsoleApp.Interfaces;
using SharedConsoleApp.Services;

namespace TestConsoleApp;

public class FileServiceTest
{
    [Fact]

   public void SaveToFileShoul_SaveContentToFileJson_TheReturnTrue()
    {

        //Arrange
        IFileService fileService = new FileService();
        string filePath = @"C:\Users\User\source\repos\SharedConsoleApp\AddressBookConsoleApp\contacts.json";
        string content = "text content";

        // Act

        bool result = fileService.SaveContentToFile(filePath, content);

        //Assert

        Assert.True(result);

    }

    [Fact]
    public void SaveToFileShoulReturnTrueIfFileDoNotExists()
    {

        //Arrange
        IFileService fileService = new FileService();
        string filePath = $@"C:\{Guid.NewGuid()}\test.json";
        string content = "text content";

        // Act

        bool result = fileService.SaveContentToFile(filePath, content);

        //Assert

        Assert.True(result);

    }

}
