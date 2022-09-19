using Moq;
using ToDoList.Infrastructure.Models;
using ToDoList.Infrastructure.Repo;

namespace ToDoList.Tests.ServiceMocks;

public class ToDoRepositoryMock : Mock<IToDoRepository>
{
    public ToDoRepositoryMock Setup_GetAll_WithCustomResponse(IEnumerable<ToDo> response)
    {
        Setup(x => x.GetAllAsync()).ReturnsAsync(response);
        return this;
    }

    public ToDoRepositoryMock Setup_GetAll_WithException()
    {
        Setup(x => x.GetAllAsync()).ThrowsAsync(new Exception());
        return this;
    }

    public ToDoRepositoryMock Setup_GetById_WithCustomResponse(ToDo response)
    {
        Setup(x => x.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(response);
        return this;
    }

    public ToDoRepositoryMock Setup_GetById_WithException()
    {
        Setup(x => x.GetByIdAsync(It.IsAny<int>())).ThrowsAsync(new Exception());
        return this;
    }

    public ToDoRepositoryMock Setup_AddNew_WithCustomResponse(bool response)
    {
        Setup(x => x.AddNewTaskAsync(It.IsAny<ToDo>())).ReturnsAsync(response);
        return this;
    }

    public ToDoRepositoryMock Setup_AddNew_WithException()
    {
        Setup(x => x.AddNewTaskAsync(It.IsAny<ToDo>())).ThrowsAsync(new Exception());
        return this;
    }

    public ToDoRepositoryMock Setup_Update_WithCustomResponse(bool response)
    {
        Setup(x => x.UpdateAsync(It.IsAny<ToDo>())).ReturnsAsync(response);
        return this;
    }

    public ToDoRepositoryMock Setup_Update_WithException()
    {
        Setup(x => x.UpdateAsync(It.IsAny<ToDo>())).ThrowsAsync(new Exception());
        return this;
    }

    public ToDoRepositoryMock Setup_Delete_WithCustomResponse(bool response)
    {
        Setup(x => x.DeleteAsync(It.IsAny<int>())).ReturnsAsync(response);
        return this;
    }

    public ToDoRepositoryMock Setup_Delete_WithException()
    {
        Setup(x => x.DeleteAsync(It.IsAny<int>())).ThrowsAsync(new Exception());
        return this;
    }
}