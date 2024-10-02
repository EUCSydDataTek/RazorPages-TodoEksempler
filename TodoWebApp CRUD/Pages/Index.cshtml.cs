using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TodoLibrary;
using TodoLibrary.Objects;

namespace TodoWebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ITodoRepository _repository;

        public List<TodoItem> Items { get; set; } = new List<TodoItem>();
        
        public IndexModel(ILogger<IndexModel> logger, ITodoRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public void OnGet()
        {
            Items = _repository.GetTodoItems();
        }

        public void OnGetCompleteTrigger(int id,bool state)
        {
            var item = _repository.GetTodoItem(id);

            if (item != null)
            {
                item.IsCompleted = state;
            }

            Items = _repository.GetTodoItems();
        }
    }
}
