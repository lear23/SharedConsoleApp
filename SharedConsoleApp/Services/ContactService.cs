
using Newtonsoft.Json;
using SharedConsoleApp.Interfaces;
using System.Diagnostics;


namespace SharedConsoleApp.Services
{
    public class ContactService : IContactService
    {
        private readonly IFileService _fileService = new FileService();

        //public ContactService(IFileService fileService)
        //{
        //    _fileService = fileService;
        //}

        private static readonly List<IContact> _contacts = new List<IContact>();
        private readonly string _filePath = @"C:\Users\User\source\repos\SharedConsoleApp\AddressBookConsoleApp\contacts.json";


        public bool AddContactToList(IContact contact)
        {
            try
            {
                if (!_contacts.Any(x => x.Email == contact.Email))
                {
                    _contacts.Add(contact);

                    var json = JsonConvert.SerializeObject(_contacts, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Objects, Formatting = Formatting.Indented });

                    var result = _fileService.SaveContentToFile(_filePath, json);
                    return result;


                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("ContactService-AddContactToFile:: " + ex.Message);
            }
            return false;
        }
      


        public bool ContactExists(object email)
        {
            return _contacts.Any(contact => contact.Email == email);


            
        }


        public IContact GetContactFromList(string email)
        {
            try
            {
                GetContactsFromList();

                var contact = _contacts.FirstOrDefault(x => x.Email == email);
                return contact ?? null!;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("ContactService-GetContactFromFile:: " + ex.Message);
            }
            return null!;
        }
      

        public IEnumerable<IContact> GetContactsFromList()
        {
            try
            {
                var content = _fileService.GetContentFromList(_filePath);

                if (!string.IsNullOrEmpty(content))
                {
                    var newContacts = JsonConvert.DeserializeObject<List<IContact>>(content, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All }) ?? new List<IContact>();

                    return newContacts;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("ContactService-GetContactsFromFile:: " + ex.Message);
            }

            return new List<IContact>();
        }

        public bool DeleteContact(string email)
        {
            try
            {
                var contact = _contacts.FirstOrDefault(x => x.Email == email);

                if (contact == null)
                {
                    Debug.WriteLine("Contact not found.");
                    return false; // Indicate contact not found
                }

                _contacts.Remove(contact);

                string json = JsonConvert.SerializeObject(_contacts, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Objects });

                var result = _fileService.SaveContentToFile(_filePath, json);

                if (!result)
                {
                    Debug.WriteLine("Error saving contacts to file.");
                   
                    _contacts.Add(contact);
                }

                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error in DeleteContact: " + ex.Message);
                return false;
            }
        }


        public bool UpdateContact(IContact existingContact, IContact updatedContact)
        {
            try
            {
                if (_contacts.Contains(existingContact))
                {
                    _contacts.Remove(existingContact);
                    _contacts.Add(updatedContact);

                    string json = JsonConvert.SerializeObject(_contacts, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.None});

                    var result = _fileService.SaveContentToFile(_filePath, json);
                    return result;                   
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("ContactService-UpdateContact:: " + ex.Message);
            }
            return false;
        }

       
    }
}


