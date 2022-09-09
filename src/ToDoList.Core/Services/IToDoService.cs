using ToDoList.Infrastructure.Models;

namespace ToDoList.Core.Services;

public interface IToDoService
{
    public Task<List<ToDo>> GetAllToDosAsync();

    public Task<ToDo> GetToDoByIdAsync(int id);

    public Task<bool> CreateNewToDoAsync(ToDo toDo);

    public Task<bool> UpdateToDoAsync(ToDo toDo);

    public Task<bool> DeleteToDoAsync(int id);
}