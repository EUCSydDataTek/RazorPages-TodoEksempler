using TodoLibrary.Objects;

namespace TodoLibrary
{
    public interface ITodoRepository
    {
        void CreateTodoItem(TodoItem item);
        void DeleteTodoItem(int id);
        TodoItem? EditTodoItem(TodoItem item);
        TodoItem? GetTodoItem(int id);
        List<TodoItem> GetTodoItems();
    }
}