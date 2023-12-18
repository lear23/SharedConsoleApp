
using Newtonsoft.Json;
using SharedConsoleApp.Interfaces;
using SharedConsoleApp.Models;
using SharedConsoleApp.Services;

namespace TestConsoleApp;

public class ContactServiceTest
{

    [Fact]
    public void AddToList_AddContactOneToList_ThenReturnTrue()
    {
        //Arrnage


        IContact _contact = new PrivateContact { FirstName = "Isra", LastName = "Morales", Address = "väg 24", Email = "loki@sverige", PhoneNumber = "0977665544" };

        IContactService contactService = new ContactService();

        //Act

        bool result = contactService.AddContactToList(_contact);

        //Assert
        Assert.True(result);


    }


    [Fact]
    public void GetAllFromListShould_GetAllContactInContactList_ThenReturnListOfContact()
    {
        //Arrange
        IContactService contactService = new ContactService();

        //Act

        IEnumerable<IContact> result = contactService.GetContactsFromList();

        IContact _contact = new PrivateContact { FirstName = "Isra", LastName = "Morales", Address = "väg 24", Email = "loki@sverige", PhoneNumber = "0977665544" };
        contactService.AddContactToList(_contact);

        //Assert


        Assert.NotNull(result);

        Assert.True(((List<IContact>)result).Any());
    }





}


