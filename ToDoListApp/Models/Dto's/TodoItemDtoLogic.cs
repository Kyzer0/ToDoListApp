using System.Security.Cryptography.X509Certificates;
using ToDoListApp.Models;
using ToDoListApp.Models.DtoModels;

namespace ToDoListApp.Dto_s
{
    public class TodoItemDtoLogic
    {
        /// <summary>
        /// Maps a CreateTodoDto object to a TodoItem object.
        /// </summary>
        /// <param name="item">The CreateTodoDto object containing the data to map.</param>
        /// <returns>A new TodoItem object with the mapped data.</returns>
        public TodoItem MapCreateTodo(CreateTodoDto item)
        {
            return new TodoItem
            {
                Title = item.Title,
                Description = item.Description,
            };
        }

        /// <summary>
        /// Maps an UpdateTodoDto object to a TodoItem object.
        /// </summary>
        /// <param name="item">The UpdateTodoDto object containing the data to map.</param>
        /// <returns>A new TodoItem object with the mapped data.</returns>
        public TodoItem MapUpdateDtos(UpdateTodoDto item)
        {
            return new TodoItem
            {
                Title = item.Title,
                Description = item.Description,
                IsCompleted = item.IsCompleted,
            };
        }

        /// <summary>
        /// Maps a TodoItem object to a TodoUpdateResponseDto object.
        /// </summary>
        /// <param name="response">The TodoItem object containing the data to map.</param>
        /// <returns>A new TodoUpdateResponseDto object with the mapped data.</returns>
        public TodoUpdateResponseDto UpdateMapResponseDto(TodoItem response)
        {
            var dto = new TodoUpdateResponseDto
            {
                Id = response.Id,
                Title = response.Title,
                Description = response.Description,
                IsCompleted = response.IsCompleted,
                TaskCreated = response.TaskCreated,
            };

            if (response.IsCompleted)
            {
                dto.TaskDone = response.TaskDone;
            }

            return dto;
        }
    }
 
}
