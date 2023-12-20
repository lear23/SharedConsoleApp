

using SharedConsoleApp.Interfaces;

namespace SharedConsoleApp.Models;

public class PrivateContact : IContact
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public Guid Guid { get; set; } = Guid.NewGuid();
    public string Email { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string Address { get; set; } = null!;



    public override string ToString()
    {
        return $"Name: {FirstName} {LastName}, Email: {Email}, Phone: {PhoneNumber}, Address: {Address}";
    }

}
