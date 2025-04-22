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

        [HttpPost]
        public async Task<IActionResult> CreateTask( CreateTodoDto item)
        {
            var response = new ResponseTodoList<TodoUpdateResponseDto>();
            if (string.IsNullOrWhiteSpace(item.Title)) 
            {
                response.IsSuccess = false;
                response.Message = "Request Body Cannot be null";
                response.Errors.Add("Invalid Input");
                return BadRequest(response); 
            }
           
            var addDto = await Task.Run(() => _dtoTodo.MapCreateTodo(item));
            
            await Task.Run(() => _items.AddTask(addDto));
            
            response.IsSuccess = true;
            response.Message ="Task Created Successfully";
            response.Data = _dtoTodo.UpdateMapResponseDto(addDto);
            
            return Ok(response); 
        }
        [HttpGet]
        public async Task<IActionResult> GetAllTask()
        {
            var listTask = await Task.Run(() => _items.GetAllTasks());

            var responseList = listTask
                .Select(task => _dtoTodo.UpdateMapResponseDto(task))
                .ToList();
            var response = new ResponseTodoList<List<TodoUpdateResponseDto>>
            {
                IsSuccess = true,
                Message = "All tasks retrieved successfully.",
                Data = responseList
            };

             return Ok(response);
        }

        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaskById(Guid id)
        {
            var response = new ResponseTodoList<TodoUpdateResponseDto>();
            if(id == Guid.Empty)
            {
                response.IsSuccess = false;
                response.Message = "Request Id Cannot be Empty or null";
                response.Errors.Add("Invalid Input");
                return BadRequest(response); 
            }
            else
            {
                var getId = await Task.Run((() => _items.GetTaskGuid(id)));
                response.IsSuccess = true;
                response.Message = "Complete Data of User: ";
                response.Data = _dtoTodo.UpdateMapResponseDto(getId);
                return Ok(response);
            }
          
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask(Guid id, [FromBody] UpdateTodoDto updateTodo)
        {
            var response = new ResponseTodoList<TodoUpdateResponseDto>();

            // Check if the provided ID is empty
            if (id == Guid.Empty)
            {
                response.IsSuccess = false;
                response.Message = "Request Id Cannot be Empty or null";
                response.Errors.Add("Invalid Input");
                return BadRequest(response);
            }

            // Check if the updateTodo object is null
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

            // Map the update DTO and update the task
            var updateDto = await Task.Run(() => _dtoTodo.MapUpdateDtos(updateTodo));
            await Task.Run(() => _items.UpdateTask(id, updateDto));

            // Prepare the response
            response.IsSuccess = true;
            response.Message = "Task Updated Successfully";
            response.Data = _dtoTodo.UpdateMapResponseDto(updateDto);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(Guid id)
        {
            var response = new ResponseTodoList<TodoUpdateResponseDto>();

            if(id == Guid.Empty)
            {
                response.IsSuccess = false;
                response.Message = "Request Id Cannot be Empty or null";
                response.Errors.Add("Invalid Input");
                return BadRequest(response); 
            }
            var getId = await Task.Run(() => _items.GetTaskGuid(id));

            await Task.Run(() => _items.DeleteTask(id));
            response.IsSuccess = true;
            response.Message = "Task Deleted Successfully";
            response.Data = _dtoTodo.UpdateMapResponseDto(getId);
            

            return Ok(response);
        }
    }
  
}
