using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers;

public class CalculatorController : Controller
{
    public IActionResult Privacy()
    {
        return View();
    }
    public enum Operator
    {
        Unknown, Add, Mul, Sub, Div
        
    }
    
    public IActionResult Calculator(Operator op, double? a, double? b)
    {
        if (a is null || b is null)
        {
            ViewBag.ErrorMessage = "Niepoprawny format liczby w parametrze a lub b";
            return View("CustomError");
        }
        //dodaj obsługę błędu dla op, jeśli jest inny od add, syb, mul, div
        if (op != Operator.Add && op != Operator.Sub && op != Operator.Mul && op != Operator.Div)
        {
            ViewBag.ErrorMessage = "Błąd parametru";
            return View("CustomError");
        }
        
        ViewBag.op = op;
        ViewBag.a = a;
        ViewBag.b = b;
        switch (op)
        {
            case Operator.Add:
                ViewBag.result = a + b;
                ViewBag.op = "+";
                break;
            case Operator.Sub:
                ViewBag.result = a - b;
                ViewBag.op = "-";
                break;
            case Operator.Mul:
                ViewBag.result = a * b;
                ViewBag.op = "*";
                break;
            case Operator.Div:
                ViewBag.result = a / b;
                ViewBag.op = ":";
                break;
            
        }
        return View();
    }
}
