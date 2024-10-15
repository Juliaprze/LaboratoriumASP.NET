using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers;

public class CalculatorController : Controller
{
    public enum Operator
    {
        Unknown, Add, Mul, Sub, Div
        
    }

    public IActionResult Form()
    {
        return View();  
    }

    [HttpPost]
    
    public IActionResult Result([FromForm] Calculator model)
    {
        if (!model.IsValid())
        {
            return View("Error",model);
        }
        return View(model);
    }
}
