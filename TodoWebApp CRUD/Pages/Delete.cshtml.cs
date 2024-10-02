using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TodoLibrary;
using TodoLibrary.Objects;

namespace TodoWebApp_CRUD.Pages
{
    public class DeleteModel : PageModel
    {

        private readonly ITodoRepository _repository;

        public DeleteModel(ITodoRepository repository)
        {
            _repository = repository;
        }

        public TodoItem TodoItem { get; set; } = default!;

        [BindProperty(SupportsGet = true)]
        public int TodoId { get; set; }

        public IActionResult OnGet()
        {
            var Item = _repository.GetTodoItem(TodoId);

            if (Item == null)
            {
                return NotFound();
            }
            
            TodoItem = Item;

            return Page();
        }

        public IActionResult OnGetConfirm()
        {
            _repository.DeleteTodoItem(TodoId);

            return RedirectToPage("index");
        }
    }
}
