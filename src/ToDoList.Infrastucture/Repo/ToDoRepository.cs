using Microsoft.EntityFrameworkCore;
using ToDoList.Infrastructure.Models;

namespace ToDoList.Infrastructure.Repo;

public class ToDoRepository : IToDoRepository
{
    private readonly ToDoContext _context;

    public ToDoRepository(ToDoContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ToDo>> GetAllAsync()
    {
        return await _context.ToDo.ToListAsync();
    }

    public async Task<ToDo> GetByIdAsync(int id)
    {
        return await _context.ToDo.FindAsync(id) ?? throw new ArgumentNullException(nameof(id), $"The task with {id} was not found in the Db");
    }

    public async Task<bool> AddNewTaskAsync(ToDo toDo)
    {
        _context.ToDo.Add(toDo);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> UpdateAsync(ToDo toDo)
    {
        var task = await _context.ToDo.FindAsync(toDo.Id) ?? throw new ArgumentNullException(nameof(toDo), $"The task with {toDo.Id} was not found in the Db");
        task.Title = toDo.Title;
        task.DateTime = toDo.DateTime;
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var task = await _context.ToDo.FindAsync(id) ?? throw new ArgumentNullException(nameof(id), $"The task with {id} was not found in the Db");
        _context.ToDo.Remove(task);
        await _context.SaveChangesAsync();
        return true;
    }

}