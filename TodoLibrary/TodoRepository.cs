using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoLibrary.Objects;

namespace TodoLibrary
{
    public class TodoRepository
    {

        private readonly List<TodoItem> _items;

        public TodoRepository() 
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
        }

        public List<TodoItem> GetTodoItems() => _items;

        public void Add(TodoItem item) => _items.Add(item);

    }
}
