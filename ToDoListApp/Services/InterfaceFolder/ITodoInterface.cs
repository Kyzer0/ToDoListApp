namespace ToDoListApp.Services.InterfaceFolder
{
    public interface ITodoInterface<T>
    {
        void AddTask(T task);
        List<T> GetAllTasks();
        T GetTaskGuid(Guid id);
        void UpdateTask(Guid id,T task);
        void DeleteTask(Guid id);
    }
}
