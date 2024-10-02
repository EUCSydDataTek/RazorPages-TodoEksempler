using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TodoLibrary;
using TodoLibrary.Objects;

namespace TodoWebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public List<TodoItem> Items { get; set; } = new List<TodoItem>();

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet([FromServices] ITodoRepository repository)
        {
            Items = repository.GetTodoItems();
        }
    }
}
