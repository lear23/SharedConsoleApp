using Microsoft.VisualBasic;

using SharedConsoleApp.Interfaces;
using SharedConsoleApp.Models;
using SharedConsoleApp.Services;



namespace AddressBookConsoleApp.Services
{
    public class MenuService : IMenuService
    {
        private readonly IContactService _contactService = new ContactService();
        private object email;

        public void ShowMainMenu()
        {
            while (true)
            {
                DisplayMenuTitle("Menu Option");

                Console.WriteLine($"{"1.",3} **Add New Contact** ");
                Console.WriteLine($"{"2.",3} **Show Contact** ");
                Console.WriteLine($"{"3.",3} **Delete Contact** ");
                Console.WriteLine($"{"4.",3} **Update Contact** ");
                Console.WriteLine($"{"5.",3} **Show All Contact** ");
                Console.WriteLine($"{"0.",3} **EXIT** ");

                Console.WriteLine();
                Console.Write("*Enter Menu Option*: ");

                var option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        ShowAddContactOption();
                        break;
                    case "2":
                        ShowViewContactListOption();
                        break;
                    case "3":
                        ShowDeleteContactOption();
                        break;
                    case "4":
                        ShowUpdateContactOption();
                        break;
                    case "5":
                        ShowAllContactOption();
                        break;
                    case "0":
                        ExitApplicationOption();
                        break;
                    default:
                        Console.WriteLine("\nInvalid Option Selected. PLEASE Try Again ");
                        Console.ReadKey();
                        break;
                }
            }
        }
        public void ShowAddContactOption()
        {
            IContact contact = new PrivateContact();

            DisplayMenuTitle("Add New Contact");
            Console.Write("Enter your First Name: ");
            contact.FirstName = Console.ReadLine()!;

            Console.Write("Enter your Last Name: ");
            contact.LastName = Console.ReadLine()!;

            Console.Write("Enter your Phone Number: ");
            contact.PhoneNumber = Console.ReadLine()!;

            Console.Write("Enter your Address: ");
            contact.Address = Console.ReadLine()!;

            Console.Write("Enter your Email: ");
            object emailObject = Console.ReadLine()!; 

            if (!_contactService.ContactExists(emailObject))
            {
                if (emailObject is string emailString)
                {
                    contact.Email = emailString; 
                    _contactService.AddContactToList(contact);

                    Console.Clear();
                    Console.WriteLine("Contact added successfully. Hello, " + contact.FirstName + "!");
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Error: Invalid email format.");
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Error: Contact with the same email already exists.");
            }

            Console.ReadKey();
            Console.Clear();
        }



        private void ShowDeleteContactOption()
        {
            Console.Write("Enter the Email of the contact to delete: ");
            var emailToDelete = Console.ReadLine();

            if (_contactService.DeleteContact(emailToDelete!))
            {
                Console.WriteLine("**Contact deleted successfully.**");

            }
            else
            {
                Console.WriteLine("Contact not found or deletion failed.");
            }

            Console.ReadKey();
        }


        private void ShowAllContactOption()
        {

            DisplayMenuTitle("--All Contacts--");

            var contacts = _contactService.GetContactsFromList();

            if (contacts.Any())
            {
                foreach (var contact in contacts)
                {
                    Console.WriteLine($"Name: {contact.FirstName} {contact.LastName}");
                    Console.WriteLine($"Phone Number: {contact.PhoneNumber}");
                    Console.WriteLine($"Address: {contact.Address}");
                    Console.WriteLine($"Email: {contact.Email}");
                    Console.WriteLine("----------------------------------");

                }
            }
            else
            {
                Console.WriteLine("No contacts found.");
            }

            Console.ReadKey();
            Console.Clear();



        }

        private void ShowUpdateContactOption()
        {
            Console.Write("Enter the Email of the contact to update: ");
            var emailToUpdate = Console.ReadLine();

            var existingContact = _contactService.GetContactFromList(emailToUpdate!);

            if (existingContact != null)
            {
                IContact updatedContact = new PrivateContact();

                Console.Write("Enter the updated First Name: ");
                updatedContact.FirstName = Console.ReadLine()!;

                Console.Write("Enter the updated Last Name: ");
                updatedContact.LastName = Console.ReadLine()!;

                Console.Write("Enter the updated Phone Number: ");
                updatedContact.PhoneNumber = Console.ReadLine()!;

                Console.Write("Enter the updated Address: ");
                updatedContact.Address = Console.ReadLine()!;

                Console.Write("Enter the updated Email: ");
                updatedContact.Email = Console.ReadLine()!;

                _contactService.UpdateContact(existingContact, updatedContact);

                Console.WriteLine("Contact updated successfully.");
            }
            else
            {
                Console.WriteLine("Contact not found.");
            }
          
            Console.ReadKey();
            Console.Clear();
        }



        private void ShowViewContactListOption()
        {
            Console.Write("Enter the Email of the contact to view details: ");
            var emailToView = Console.ReadLine();

            if (string.IsNullOrEmpty(emailToView))
            {
                Console.WriteLine("Invalid email. Please try again.");
                Console.ReadKey();
                Console.Clear();
                return;
            }

            var contact = _contactService.GetContactFromList(emailToView);

            if (contact != null)
            {
                DisplayMenuTitle("Contact Details");
                Console.WriteLine(contact);
               
            }
            else
            {
                Console.WriteLine("Contact not found.");
            }

            Console.ReadKey();
            Console.Clear();
        }




        private void ExitApplicationOption()
        {
            Console.Clear();
            Console.Write("Are you sure you want to exit? (yes/no): ");
            var answer = Console.ReadLine() ?? "";

            if (answer.Equals("yes", StringComparison.CurrentCultureIgnoreCase))
            {
                Environment.Exit(0);
            }
        }

        private void DisplayMenuTitle(string title)
        {
            Console.Clear();
            Console.WriteLine($"### {title} ###");
            Console.WriteLine();
        }
    }
}

