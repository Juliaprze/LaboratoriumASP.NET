using LaboratoriumASPNET.Models;

namespace WebApplication1.Models;

public class OrganizationEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Regon { get; set; }
    public string Nip { get; set; }
    public Adress? Adress { get; set; }     //Klasa osadzona
    public ISet<ContactEntity> Contacts { get; set; }    //Właściwość nawigacyjna - osobna tabela
}

public class Adress
{
    public string City { get; set; }
    public string Street { get; set; }
}
