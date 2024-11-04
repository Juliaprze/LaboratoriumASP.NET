using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models;

public enum Category
{
    [Display(Name ="Family")]
    Family = 1,
    
    [Display(Name ="Friend")]
    Friend = 2,
    
    [Display(Name ="Business")]
    Business = 4,
    
}