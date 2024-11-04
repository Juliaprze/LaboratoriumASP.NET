using WebApplication1.Models;


namespace LaboratoriumASPNET.Models.Services;

public class MemoryContactService : IContactService
{
    private Dictionary<int, ContactModel> _contacts = new()
    {
        {
            1,
            new ContactModel
            {
                FirstName = "John",
                LastName = "Doe",
                Category = Category.Family,
                Id = 1,
                Email = "john.doe@gmail.com",
                Phone = "088 888 888",
                DateOfBirth = new DateTime(2005, 1, 1)
            }
        },
        {
            2,
            new ContactModel
            {
                FirstName = "Eve",
                LastName = "Fisher",
                Category = Category.Friend,
                Id = 2,
                Email = "eve.fisher@gmail.com",
                Phone = "8886 777 789",
                DateOfBirth = new DateTime(2000, 10, 2)
            }
        },
        {
            3,
            new ContactModel
            {
                FirstName = "Mark",
                LastName = "Hamster",
                Category = Category.Business,
                Id = 3,
                Email = "m.hamster@gmail.com",
                Phone = "822 288 886",
                DateOfBirth = new DateTime(1900, 10, 1)
            }
        }
    };

    private int _index = 3;

    public void Add(ContactModel model)
    {
        model.Id = ++_index;
        _contacts.Add(model.Id, model);
    }

    public void Update(ContactModel contact)
    {
        if (_contacts.ContainsKey(contact.Id))
        {
            _contacts[contact.Id] = contact;
        }
    }

    public void Delete(int id)
    {
        _contacts.Remove(id);
    }

    public List<ContactModel> GetAll()
    {
        return _contacts.Values.ToList();
    }

    public ContactModel? GetById(int id)
    {
        _contacts.TryGetValue(id, out var contact);
        return contact;
    }
}