namespace ToDoListApp.ResponseFolder
{
    /// <summary>
    /// add response value
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ResponseTodoList<T>
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
        public List<string> Errors { get; set; } = new();

   
    }
}
