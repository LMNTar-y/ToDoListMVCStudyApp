using Microsoft.Extensions.Logging;
using ToDoList.Infrastructure.Models;
using ToDoList.Infrastructure.Repo;

namespace ToDoList.Core.Services;

public class ToDoService : IToDoService
{
    private readonly IToDoRepository _repository;
    private readonly ILogger<ToDoService> _logger;

    public ToDoService(IToDoRepository repository, ILogger<ToDoService> logger)
    {
        _repository = repository
                      ?? throw new ArgumentNullException(nameof(repository), $"Initialization failure due to: {repository}");
        _logger = logger
                  ?? throw new ArgumentNullException(nameof(logger), $"Initialization failure due to: {logger}");
    }

    public async Task<List<ToDo>> GetAllToDosAsync()
    {
        _logger.LogInformation("GetAllToDosAsync start");
        return (await _repository.GetAllAsync()).ToList();
    }

    public async Task<ToDo> GetToDoByIdAsync(int id)
    {
        _logger.LogInformation($"GetToDoByIdAsync start: {id}");
        return await _repository.GetByIdAsync(id);
    }

    public async Task<bool> CreateNewToDoAsync(ToDo toDo)
    {
        _logger.LogInformation("CreateNewToDoAsync start");

        return await _repository.AddNewTaskAsync(toDo);
    }

    public async Task<bool> UpdateToDoAsync(ToDo toDo)
    {
        _logger.LogInformation("UpdateToDoAsync start");

        return await _repository.UpdateAsync(toDo);
    }

    public async Task<bool> DeleteToDoAsync(int id)
    {
        _logger.LogInformation("DeleteAsync start");

        return await _repository.DeleteAsync(id);
    }
}