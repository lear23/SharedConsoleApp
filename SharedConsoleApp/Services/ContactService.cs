
using Newtonsoft.Json;
using SharedConsoleApp.Interfaces;
using SharedConsoleApp.Models;
using System.Diagnostics;


namespace SharedConsoleApp.Services
{
    public class ContactService : IContactService
    {
        private readonly IFileService _fileService = new FileService();


        private static readonly List<IContact> _contacts = new List<IContact>();
        private readonly string _filePath = @"C:\Users\User\source\repos\SharedConsoleApp\contacts.json";
        public PrivateContact CurrentItem { get; set; } = null!;
        

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
                    var newContacts = JsonConvert.DeserializeObject<List<IContact>>(content, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All }) ?? [];

                    return newContacts;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("ContactService-GetContactsFromFile:: " + ex.Message);
            }

            return _contacts;
        }



        public bool DeleteContact(object contactOrEmail)
        {
            try
            {
                PrivateContact contactToDelete = null!;

                if (contactOrEmail is PrivateContact)
                {
                
                    contactToDelete = (PrivateContact)contactOrEmail;
                }
                else if (contactOrEmail is string)
                {
                    
                    var email = (string)contactOrEmail;
                    contactToDelete = (PrivateContact?)_contacts.FirstOrDefault(x => x.Email == email)!;
                }
                else
                {
                   
                    Debug.WriteLine("Unsupported type for contactOrEmail.");
                    return false;
                }

                if (contactToDelete == null)
                {
                    Debug.WriteLine("Contact not found.");
                    return false;
                }

                _contacts.Remove(contactToDelete);

                string json = JsonConvert.SerializeObject(_contacts, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Objects });

                var result = _fileService.SaveContentToFile(_filePath, json);

                if (!result)
                {
                    Debug.WriteLine("Error saving contacts to file.");
                    _contacts.Add(contactToDelete);
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

                    string json = JsonConvert.SerializeObject(_contacts, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.None });

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


