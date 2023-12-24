using static SharedConsoleApp.Services.ContactService;

namespace SharedConsoleApp.Interfaces
{
    public interface IContactService
    {
        bool AddContactToList(IContact contact);
        IEnumerable<IContact> GetContactsFromList();
        IContact GetContactFromList(string email);
        bool UpdateContact(IContact existingContact, IContact updatedContact);
        bool DeleteContact(object contactOrEmaill);
        bool ContactExists(object email);
    }
}
















