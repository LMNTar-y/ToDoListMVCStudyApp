using System.ComponentModel.DataAnnotations;

namespace ToDoList.Infrastructure.Models
{
    public class ToDo
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }

    }
}