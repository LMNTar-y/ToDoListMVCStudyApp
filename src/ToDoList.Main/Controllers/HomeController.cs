using Microsoft.AspNetCore.Mvc;
using ToDoList.Core.Services;
using ToDoList.Infrastructure.Models;
using ToDoList.Main.Model;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ToDoList.Main.Controllers;

public class HomeController : Controller
{
    private readonly IToDoService _service;

    public HomeController(IToDoService service)
    {
        _service = service ?? throw new ArgumentNullException($"Initialization failure due to: {service}");
    }

    public async Task<IActionResult> Index()
    {
        var todos = new ToDoViewModel();
        todos.ToDoList = (await GetAllToDos()).ToList();
        return View(todos);
    }

    public async Task<IEnumerable<ToDo>> GetAllToDos()
    {
        return await _service.GetAllToDosAsync();
    }

    public async Task<RedirectToActionResult> Insert(ToDo toDo)
    {
        await _service.CreateNewToDoAsync(toDo);

        return RedirectToAction("Index");
    }

    [HttpDelete]
    public async Task<JsonResult> Delete(int id)
    {
        var result = await _service.DeleteToDoAsync(id);
        return Json(new { result });
    }

    public async Task<RedirectToActionResult> Update(ToDo toDo)
    {
        await _service.UpdateToDoAsync(toDo);
        return RedirectToAction("Index");
    }

    [HttpGet]
    public async Task<JsonResult> PopulateForm(int id)
    {
        var toDo = await _service.GetToDoByIdAsync(id);
        return Json(toDo);
    }
}