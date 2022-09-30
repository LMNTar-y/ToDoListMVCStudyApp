using System.ComponentModel.DataAnnotations;

namespace ToDoList.Infrastructure.Models
{
    public class ToDo
    {
        public int Id { get; set; }
        [Required]
        public string? Title { get; set; }
        [Required]
        public DateTime? DateTime { get; set; }

    }
}