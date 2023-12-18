using SharedConsoleApp.Interfaces;


namespace SharedConsoleApp.Interfaces
{
    public interface IPrivateContact 
    {
       
        string FirstName { get; set; }
        string LastName { get; set; }
        string Email { get; set; }
    }
}