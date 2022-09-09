using ToDoList.Infrastructure.Models;

namespace ToDoList.Infrastructure.Repo;

public interface IToDoRepository
{
    public Task<IEnumerable<ToDo>> GetAllAsync();

    public Task<ToDo> GetByIdAsync(int id);

    public Task<bool> AddNewTaskAsync(ToDo toDo);

    public Task<bool> UpdateAsync(ToDo toDo);

    public Task<bool> DeleteAsync(int id);
}