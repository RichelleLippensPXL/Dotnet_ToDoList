using Microsoft.AspNetCore.Mvc;
using ToDoListApp.AppLogic;
using ToDoListApp.Web.Models;

namespace ToDoListApp.Web.Controllers
{
    public class ToDoListController : Controller
    {
        private readonly IToDoListRepository _toDoListRepository;

        public ToDoListController(IToDoListRepository toDoListRepository)
        {
            _toDoListRepository = toDoListRepository;
        }

        public IActionResult Detail(Guid id)
        {     
            if (id == Guid.Empty)
            {
                return RedirectToAction("Index", "Home");
            }
            var list = _toDoListRepository.GetById(id);
            ToDoListDetailViewModel model = new ToDoListDetailViewModel(list);
            return View(model);
        }
        [HttpPost]
        public IActionResult Detail(ToDoListDetailViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            _toDoListRepository.AddItemToExistingList(model.ListId, model.NewItemDescription);
            var list = _toDoListRepository.GetById(model.ListId);
            model = new ToDoListDetailViewModel(list);
            return View(model);
        }


    }
}
