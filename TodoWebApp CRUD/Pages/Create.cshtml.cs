using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using TodoLibrary;
using TodoLibrary.Objects;

namespace TodoWebApp_CRUD.Pages
{
    public class CreateModel : PageModel
    {

        private readonly ITodoRepository _repository;

        [Required]
        [MaxLength(20)]
        [BindProperty]
        public string TodoName { get; set; } = string.Empty;

        public CreateModel(ITodoRepository repository)
        {
            _repository = repository;
        }

        public void OnGet()
        {}

        public IActionResult OnPost() 
        {
            var newItem = new TodoItem() 
            {
                Name = TodoName
            };

            _repository.CreateTodoItem(newItem);

            return RedirectToPage("index");
        }
    }
}
