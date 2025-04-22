using ToDoListApp.Models;

namespace TestTodoApp
{
    public class UnitTest1
    {
        private readonly List<TodoItem> _todo = new();

        [Fact]
        public void CheckAdd()
        {
            // Arrange
            var newItem = new TodoItem
            {
                Id = Guid.NewGuid(),
                Title = "Test Task",
                Description = "Test Description",
                IsCompleted = false
            };

            // Act
            _todo.Add(newItem);

            // Assert
            Assert.Contains(newItem, _todo);
        }

        [Fact]
        public void CheckRead()
        {
            // Arrange
            var existingItem = new TodoItem
            {
                Id = Guid.NewGuid(),
                Title = "Existing Task",
                Description = "Existing Description",
                IsCompleted = false
            };
            _todo.Add(existingItem);

            // Act
            var retrievedItem = _todo.FirstOrDefault(item => item.Id == existingItem.Id);

            // Assert
            Assert.NotNull(retrievedItem);
            Assert.Equal(existingItem.Title, retrievedItem?.Title);
        }

        [Fact]
        public void CheckUpdate()
        {
            // Arrange
            var existingItem = new TodoItem
            {
                Id = Guid.NewGuid(),
                Title = "Old Task",
                Description = "Old Description",
                IsCompleted = false
            };
            _todo.Add(existingItem);

            // Act
            var itemToUpdate = _todo.FirstOrDefault(item => item.Id == existingItem.Id);
            if (itemToUpdate != null)
            {
                itemToUpdate.Title = "Updated Task";
                itemToUpdate.Description = "Updated Description";
                itemToUpdate.IsCompleted = true;
            }

            // Assert
            Assert.NotNull(itemToUpdate);
            Assert.Equal("Updated Task", itemToUpdate?.Title);
            Assert.Equal("Updated Description", itemToUpdate?.Description);
            Assert.True(itemToUpdate?.IsCompleted);
        }

        [Fact]
        public void CheckDelete()
        {
            // Arrange
            var existingItem = new TodoItem
            {
                Id = Guid.NewGuid(),
                Title = "Task to Delete",
                Description = "Description to Delete",
                IsCompleted = false
            };
            _todo.Add(existingItem);

            // Act
            var itemToDelete = _todo.FirstOrDefault(item => item.Id == existingItem.Id);
            if (itemToDelete != null)
            {
                _todo.Remove(itemToDelete);
            }

            // Assert
            Assert.DoesNotContain(existingItem, _todo);
        }
    }
}
