using System;
using Microsoft.AspNetCore.Mvc;

public class ErrorController : Controller
{
    [HttpGet("statuscode/{code}")]
    public IActionResult Index(int code)
    {
        return View(code);
    }
}