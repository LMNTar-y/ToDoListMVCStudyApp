using Microsoft.AspNetCore.Mvc;
using ToDoList.Core.Services;
using ToDoList.Infrastructure.Models;

namespace ToDoList.Main.Controllers;

public class ToDoController : Controller
{
    private readonly IToDoService _service;

    public ToDoController(IToDoService service)
    {
        _service = service ?? throw new ArgumentNullException($"Initialization failure due to: {service}");
    }

    // GET
    public async Task<IActionResult> Index()
    {
        var toDoDetails = await _service.GetAllToDosAsync() ?? new List<ToDo>();

        return View(toDoDetails);
    }

    #region Create
    public IActionResult Create()
    {
        return View();
    }


    [HttpPost]
    public async Task<IActionResult> Create(ToDo toDo)
    {
        if (ModelState.IsValid)
        {
            var saveStatus = await _service.CreateNewToDoAsync(toDo);

            if (saveStatus)
            {
                TempData["Success"] = "The item has been created!";

                return RedirectToAction("Index");
            }
        }

        return View(toDo);

    }
    #endregion

    #region Edit
    public async Task<ActionResult> Edit(int id)
    {
        var item = await _service.GetToDoByIdAsync(id);

        if (item == null)
        {
            return NotFound();
        }

        return View(item);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(ToDo item)
    {
        if (ModelState.IsValid)
        {
            if (await _service.UpdateToDoAsync(item))
            {
                TempData["Success"] = "The item has been updated!";

                return RedirectToAction("Index");
            }
        }

        return View(item);
    }
    #endregion

    #region Delete
    public async Task<ActionResult> Delete(int id)
    {
        await _service.DeleteToDoAsync(id);

        TempData["Success"] = "The item has been deleted!";

        return RedirectToAction("Index");
    }
    #endregion
}