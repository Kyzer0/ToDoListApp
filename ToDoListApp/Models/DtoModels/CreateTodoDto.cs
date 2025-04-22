using System.ComponentModel.DataAnnotations;

namespace ToDoListApp.Models.DtoModels
{
    public class CreateTodoDto
    {
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; } = null;
    }
    public class UpdateTodoDto
    {
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; } = null;
        public bool IsCompleted { get; set; }
    }
    public class TodoUpdateResponseDto
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; } = null;
        public DateTime TaskCreated { get; set; } = DateTime.Now;
        public DateTime? TaskDone { get; set; } = null;
        public bool IsCompleted { get; set; } = false;
    }


}
