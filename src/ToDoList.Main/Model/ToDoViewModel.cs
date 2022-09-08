using ToDoList.Infrastructure.Models;

namespace ToDoList.Main.Model;

public class ToDoViewModel
{
    public List<ToDo>? ToDoList { get; set; }
    public ToDo? ToDo { get; set; }
}