using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using TodoLibrary;
using TodoLibrary.Objects;

namespace TodoWebApp_CRUD.Pages
{
    public class EditModel : PageModel
    {

        private readonly ITodoRepository _repository;

        public EditModel(ITodoRepository repository)
        {
            _repository = repository;
        }

        [BindProperty(SupportsGet = true)]
        public int TodoId { get; set; }

        [BindProperty]
        public FormModel form { get; set; } = new FormModel();

        public TodoItem Item { get; set; } = new TodoItem();

        public IActionResult OnGet()
        {
            Item = _repository.GetTodoItem(TodoId) ?? null!;

            if (Item == null)
            {
                return NotFound();
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            var item = _repository.GetTodoItem(TodoId);

            if (item == null)
            {
                return NotFound();
            }

            item.Name = form.Name;
            item.IsCompleted = form.IsCompleted;

            _repository.EditTodoItem(item);

            return RedirectToPage("index");
        }

        public class FormModel
        {
            [Required]
            [MaxLength(20)]
            public string Name { get; set; } = string.Empty;

            public bool IsCompleted { get; set; } = default!;
        }

        
    }
}
