using Microsoft.AspNetCore.Mvc;

namespace ToDoList.Main.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}