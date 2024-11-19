using WebApplication1.Models;

namespace LaboratoriumASPNET.Models;

public class ContactMapper
{
    public static ContactModel FromEntity(ContactEntity entity)
    {
        return new ContactModel()
        {
            Id = entity.Id,
            FirstName = entity.FirstName,
            LastName = entity.LastName,
            DateOfBirth = entity.DateOfBirth,
            Phone = entity.Phone,
            Email = entity.Email,
            Category = (Category)entity.Category, 
            OrganizationId = entity.OrganizationId
        };
    }

    public static ContactEntity ToEntity(ContactModel model)
    {
        return new ContactEntity()
        {
            Id = model.Id,
            FirstName = model.FirstName,
            LastName = model.LastName,
            DateOfBirth = model.DateOfBirth,
            Phone = model.Phone,
            Email = model.Email,
            Category = (int)model.Category, 
            OrganizationId = model.OrganizationId
        };
    }
}