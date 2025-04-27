using System.ComponentModel.DataAnnotations;

namespace ToDoListApp.Models.DtoModels
{
    public abstract class TodoBaseDto
    {
        [Required]
        [StringLength(int.MaxValue, MinimumLength = 3, ErrorMessage = "Title must be at least 3 characters long.")]
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; } = null;

    }
    /// <summary>
    /// Represents the data transfer object for creating a new to-do item.
    /// </summary>
    public class CreateTodoDto: TodoBaseDto
    {
        //no need to redefine for now
    }
    /// <summary>
    /// Represents the data transfer object for updating an existing to-do item.
    /// </summary>
    public class UpdateTodoDto : TodoBaseDto
    {
        public bool IsCompleted { get; set; }
    }
    /// <summary>
    /// Represents the response data transfer object for a to-do item update operation.
    /// </summary>
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
