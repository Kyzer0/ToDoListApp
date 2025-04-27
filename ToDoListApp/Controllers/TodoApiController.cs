using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using ToDoListApp.Dto_s;
using ToDoListApp.Models;
using ToDoListApp.Models.DtoModels;
using ToDoListApp.ResponseFolder;
using ToDoListApp.Services.InterfaceFolder;

namespace ToDoListApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoApiController : ControllerBase
    {
        private readonly TodoItemDtoLogic _dtoTodo;
        private readonly ITodoInterface<TodoItem> _items;

        public TodoApiController(TodoItemDtoLogic dtoTodo, ITodoInterface<TodoItem> _items)
        {
            _dtoTodo = dtoTodo;
            this._items = _items;
        }

        // Endpoint to create a new task
        [HttpPost]
        public async Task<IActionResult> CreateTask(CreateTodoDto item)
        {
            var response = new ResponseTodoList<TodoUpdateResponseDto>();

            // Validate the input to ensure the title is not null or empty
            if (string.IsNullOrWhiteSpace(item.Title))
            {
                response.IsSuccess = false;
                response.Message = "Request Body Cannot be null";
                response.Errors.Add("Invalid Input");
                return BadRequest(response);
            }

            // Map the CreateTodoDto to a TodoItem object
            var addDto = await Task.Run(() => _dtoTodo.MapCreateTodo(item));

            // Add the new task to the data store
            await Task.Run(() => _items.AddTask(addDto));

            // Prepare the success response
            response.IsSuccess = true;
            response.Message = "Task Created Successfully";
            response.Data = _dtoTodo.UpdateMapResponseDto(addDto);

            return Ok(response);
        }

        // Endpoint to retrieve all tasks
        [HttpGet]
        public async Task<IActionResult> GetAllTask()
        {
            // Retrieve all tasks from the data store
            var listTask = await Task.Run(() => _items.GetAllTasks());

            // Map each task to a response DTO
            var responseList = listTask
                .Select(task => _dtoTodo.UpdateMapResponseDto(task))
                .ToList();

            // Prepare the success response
            var response = new ResponseTodoList<List<TodoUpdateResponseDto>>
            {
                IsSuccess = true,
                Message = "All tasks retrieved successfully.",
                Data = responseList
            };

            return Ok(response);
        }

        // Endpoint to retrieve a task by its ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaskById(Guid id)
        {
            var response = new ResponseTodoList<TodoUpdateResponseDto>();

            // Validate the input to ensure the ID is not empty
            if (id == Guid.Empty)
            {
                response.IsSuccess = false;
                response.Message = "Request Id Cannot be Empty or null";
                response.Errors.Add("Invalid Input");
                return BadRequest(response);
            }
            else
            {
                // Retrieve the task by its ID
                var getId = await Task.Run(() => _items.GetTaskGuid(id));

                // Map the task to a response DTO
                response.IsSuccess = true;
                response.Message = "Complete Data of User: ";
                response.Data = _dtoTodo.UpdateMapResponseDto(getId);
                return Ok(response);
            }
        }

        // Endpoint to update an existing task
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask(Guid id, [FromBody] UpdateTodoDto updateTodo)
        {
            var response = new ResponseTodoList<TodoUpdateResponseDto>();

            // Validate the input to ensure the ID is not empty
            if (id == Guid.Empty)
            {
                response.IsSuccess = false;
                response.Message = "Request Id Cannot be Empty or null";
                response.Errors.Add("Invalid Input");
                return BadRequest(response);
            }

            // Validate the input to ensure the update data is not null
            if (updateTodo == null)
            {
                response.IsSuccess = false;
                response.Message = "Request Body Cannot be null";
                response.Errors.Add("Invalid Input");
                return BadRequest(response);
            }

            // Retrieve the existing task to ensure it exists
            var existingTask = await Task.Run(() => _items.GetTaskGuid(id));

            if (existingTask == null)
            {
                response.IsSuccess = false;
                response.Message = "Task not found";
                response.Errors.Add("Invalid Task ID");
                return NotFound(response);
            }

            // Map the update DTO to a TodoItem object and update the task
            var updateDto = await Task.Run(() => _dtoTodo.MapUpdateDtos(updateTodo));
            await Task.Run(() => _items.UpdateTask(id, updateDto));

            // Prepare the success response
            response.IsSuccess = true;
            response.Message = "Task Updated Successfully";
            response.Data = _dtoTodo.UpdateMapResponseDto(updateDto);

            return Ok(response);
        }

        // Endpoint to delete a task by its ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(Guid id)
        {
            var response = new ResponseTodoList<TodoUpdateResponseDto>();

            // Validate the input to ensure the ID is not empty
            if (id == Guid.Empty)
            {
                response.IsSuccess = false;
                response.Message = "Request Id Cannot be Empty or null";
                response.Errors.Add("Invalid Input");
                return BadRequest(response);
            }

            // Retrieve the task by its ID to ensure it exists
            var getId = await Task.Run(() => _items.GetTaskGuid(id));

            // Delete the task from the data store
            await Task.Run(() => _items.DeleteTask(id));

            // Prepare the success response
            response.IsSuccess = true;
            response.Message = "Task Deleted Successfully";
            response.Data = _dtoTodo.UpdateMapResponseDto(getId);

            return Ok(response);
        }
    }
  
}
