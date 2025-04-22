using System.Net.Http.Json;
using ToDoListApp.Models.DtoModels;

public class TodoService
{
    private readonly HttpClient _httpClient;

    public TodoService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<TodoResponseDto>> GetTodosAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<TodoResponseDto>>("TodoApi");
    }

    public async Task<TodoResponseDto> GetTodoByIdAsync(Guid id)
    {
        return await _httpClient.GetFromJsonAsync<TodoResponseDto>($"TodoApi/{id}");
    }

    public async Task<HttpResponseMessage> CreateTodoAsync(CreateTodoDto newTodo)
    {
        return await _httpClient.PostAsJsonAsync("TodoApi", newTodo);
    }

    public async Task<HttpResponseMessage> UpdateTodoAsync(Guid id, UpdateTodoDto updatedTodo)
    {
        return await _httpClient.PutAsJsonAsync($"TodoApi/{id}", updatedTodo);
    }

    public async Task<HttpResponseMessage> DeleteTodoAsync(Guid id)
    {
        return await _httpClient.DeleteAsync($"TodoApi/{id}");
    }
}
