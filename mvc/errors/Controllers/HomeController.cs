using System;
using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        throw new Exception("Error");
        
        return View();
    }
    public IActionResult Error()
    {
        return View();
    }
}