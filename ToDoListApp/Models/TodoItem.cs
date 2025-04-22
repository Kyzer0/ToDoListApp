using System.ComponentModel.DataAnnotations;

namespace ToDoListApp.Models
{
    /// <summary>
    /// Main Model for the TodoItem
    /// </summary>
    public class TodoItem
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; } = null;
        public DateTime TaskCreated { get; } = DateTime.Now;
        public DateTime TaskDone { get; set; } = DateTime.Now;
        public bool IsCompleted { get; set; } = false;
    }

   
}
