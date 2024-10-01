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
        private static int _count = 0;

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

            _count = 2;
        }

        public List<TodoItem> GetTodoItems() => _items;

        public void CreateItem(TodoItem item)
        {
            item.Id = _count;
            _count++;

            _items.Add(item);
        }

    }
}
