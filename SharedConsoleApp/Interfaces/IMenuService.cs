namespace SharedConsoleApp.Interfaces;


public interface IMenuService
{
    void ShowMainMenu();


}




















//using SharedConsoleApp.Interfaces;
//using SharedConsoleApp.Models;
//using SharedConsoleApp.Services;

//namespace AddressBookConsoleApp.Services;
////Här är internal för att det inte går att testa med readline 
//internal class MenuService
//{
//    private static readonly IContactService _contactService = new ContactService();

//    public static void AddPrivateContactMenu()
//    {
//        IPrivateContact privateContact = new PrivateContact();

//        Console.WriteLine("enter you First name: ");
//        privateContact.FirstName = Console.ReadLine()!;

//        Console.WriteLine("enter you last name: ");
//        privateContact.LastName = Console.ReadLine()!;

//        Console.WriteLine("enter you Phone Number: ");
//        privateContact.PhoneNumber = Console.ReadLine()!;

//        Console.WriteLine("enter you Address: ");
//        privateContact.Address = Console.ReadLine()!;

//        Console.WriteLine("enter you E-mail: ");
//        privateContact.Email = Console.ReadLine()!;

//        _contactService.AddContactToList(privateContact);

//    }


//    public static void ShowAllPrivateContactMenu()
//    {
//        var contacts = _contactService.GetContactsFromList();
//        foreach (var item in contacts)
//        {
//            if (item is IPrivateContact contact)
//                Console.WriteLine($"{contact.FirstName} {contact.LastName} {contact.PhoneNumber} {contact.Address} {contact.Email}");



//        }

//        Console.WriteLine();
//    }


//}
