using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoLibrary.Objects;

namespace TodoLibrary
{
    public class TodoRepository : ITodoRepository
    {

        private readonly ILogger<TodoRepository> _logger;

        public TodoRepository(ILogger<TodoRepository> logger)
        {
            _items = new List<TodoItem>() {
                new TodoItem()
                {
                    Id = 1,
                    Name = "Test",
                    Created = DateTime.Now,
                    IsCompleted = false,
                }
            };


            _count = 2;

            _logger = logger;
        }

        private static int _count = 0;

        private readonly List<TodoItem> _items;

        public List<TodoItem> GetTodoItems() => _items;

        public TodoItem? GetTodoItem(int id)
        {
            return _items.Where(i => i.Id == id).FirstOrDefault();
        }

        public void CreateTodoItem(TodoItem item)
        {
            item.Id = _count;
            _count++;

            _items.Add(item);
        }

        public TodoItem? EditTodoItem(TodoItem item)
        {
            var itemToBeEdited = _items.Where(i => i.Id == item.Id).FirstOrDefault();

            if (itemToBeEdited != null)
            {
                itemToBeEdited.Name = item.Name;
                itemToBeEdited.IsCompleted = item.IsCompleted;
            }

            return null;
        }

        public void DeleteTodoItem(int id)
        {
            var item = _items.Where(i => i.Id == id).FirstOrDefault();

            if (item != null)
            {
                _items.Remove(item);
            }
        }

    }
}
