using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoList.Infrastructure;
using ToDoList.Infrastructure.Models;
using ToDoList.Main.Model;

namespace ToDoList.Main.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ToDoContext _context;

        public HomeController(ILogger<HomeController> logger, ToDoContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var todos = new ToDoViewModel();
            todos.ToDoList = await GetAllToDos();
            return View(todos);
        }

        public async Task<List<ToDo>> GetAllToDos()
        {
            return await _context.ToDo.ToListAsync();

        }
        public async Task<RedirectToActionResult> Insert(ToDo toDo)
        {
            try
            {
                _context.ToDo.Add(toDo);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Impossible to add new ToDo item - {ex.Message}", ex);
            }

            return RedirectToAction("Index"); 
        }

        [HttpDelete]
        public async Task<JsonResult> Delete(int id)
        {
            var toDo = await _context.ToDo.FindAsync(id);
            if (toDo != null)
            {
                _context.ToDo.Remove(toDo);
                await _context.SaveChangesAsync();
            }
            return Json(new { });
        }

        public async Task<RedirectToActionResult> Update(ToDo toDo)
        {
            var t = await _context.ToDo.FindAsync(toDo.Id);
            t.Name = toDo.Name;
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<JsonResult> PopulateForm(int id)
        {
            var toDo = await _context.ToDo.FindAsync(id);
            return toDo == null ? Json(new {}) : Json(toDo);
        }
    }
}