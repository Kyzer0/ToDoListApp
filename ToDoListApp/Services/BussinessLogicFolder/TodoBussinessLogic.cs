using ToDoListApp.Models;
using ToDoListApp.Services.InterfaceFolder;

namespace Services.BussinessLogicFolder
{
    public class TodoBussinessLogic : ITodoInterface<TodoItem>
    {
        private readonly List<TodoItem> _items = new();

        public void AddTask(TodoItem item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));
            

            var newId = Guid.NewGuid();
            item.Id = newId;
             _items.Add(item);
        }

        public void DeleteTask(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentException("ID cannot be Empty");
            var item = _items.FirstOrDefault(x => x.Id == id);
            if (item == null)
                throw new ArgumentException($"{nameof(TodoItem)} not found");

            _items.Remove(item);
        }
        public List<TodoItem> GetAllTasks() => _items;

        public TodoItem GetTaskGuid(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentException("ID cannot be Empty");

            var item = _items.FirstOrDefault(x => x.Id == id);

            if (item == null)
                throw new ArgumentException($"{nameof(TodoItem)} not found");

            return item;
        }

        public void UpdateTask(Guid id, TodoItem updatedItem)
        {
            if (updatedItem == null)
                throw new ArgumentNullException(nameof(updatedItem));

            var existingItem = _items.FirstOrDefault(x => x.Id == id);
            if (existingItem == null)
                throw new ArgumentException($"{nameof(TodoItem)} not found");

                existingItem.Title = updatedItem.Title;
                existingItem.Description = updatedItem.Description;
                existingItem.IsCompleted = updatedItem.IsCompleted;
        }

    }
}
