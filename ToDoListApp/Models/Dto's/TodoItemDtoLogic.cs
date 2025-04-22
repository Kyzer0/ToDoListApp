using System.Security.Cryptography.X509Certificates;
using ToDoListApp.Models;
using ToDoListApp.Models.DtoModels;

namespace ToDoListApp.Dto_s
{
    public  class TodoItemDtoLogic
    {

        public TodoItem MapCreateTodo(CreateTodoDto item)
        {
            return new TodoItem
            {
                Title = item.Title,
                Description = item.Description,
                
            };
        }

        public TodoItem MapUpdateDtos(UpdateTodoDto item)
        {
            return new TodoItem
            {
                Title = item.Title,
                Description = item.Description,
                IsCompleted = item.IsCompleted,
            };
        }

        public TodoUpdateResponseDto UpdateMapResponseDto(TodoItem response)
        {
            var dto = new  TodoUpdateResponseDto
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
