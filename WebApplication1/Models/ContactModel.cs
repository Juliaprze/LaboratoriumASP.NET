using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices.JavaScript;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Models;

public class ContactModel
{
    [HiddenInput]
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Please enter your name!")]
    [MaxLength(length: 20, ErrorMessage = "Name must be between 2 and 20 characters!")]
    public string FirstName { get; set; }
    
    [Required(ErrorMessage = "Please enter your surname!")]
    [MaxLength(length: 20, ErrorMessage = "Surname must be between 2 and 51 characters!")]
    public string LastName { get; set; }
    
    [EmailAddress(ErrorMessage = "Please enter a valid email address!")]
    public string Email { get; set; }
    
    [Phone(ErrorMessage = "Please enter a valid phone number!")]
    [RegularExpression(pattern:"\\d\\d\\d \\d\\d\\d \\d\\d\\d", ErrorMessage = "Please enter a valid phone number!")]
    public string Phone { get; set; }
    
    [DataType(DataType.Date)]
    public DateOnly DateOfBirth { get; set; }

}