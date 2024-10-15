﻿using WebApplication1.Models;
using Microsoft.AspNetCore.Mvc;


namespace WebApplication1.Controllers;

public class BirthController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Result([FromForm]Birth model)
    {
        if(!model.IsValid())
        {
            return View("Error", model);
        }

        return View(model);
    }

    public IActionResult Form() 
    {
        return View();
    }
}
