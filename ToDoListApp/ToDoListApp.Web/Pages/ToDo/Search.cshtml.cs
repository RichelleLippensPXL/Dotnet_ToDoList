using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ToDoListApp.AppLogic;
using ToDoListApp.Domain;

namespace ToDoListApp.Web.Pages.ToDo
{
    public class SearchModel : PageModel
    {
        private readonly IToDoListRepository _toDoListRepository;

        [BindProperty]
        public string TitleFilter { get; set; }

        public IList<ToDoList> ToDoLists {get; set;}
        public SearchModel(IToDoListRepository toDoListRepository)
        {
            _toDoListRepository = toDoListRepository;
        }
        
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            ToDoLists = _toDoListRepository.Find(TitleFilter) ?? new List<ToDoList>(); ;
            return Page();
        }
    }
}
