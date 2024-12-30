using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListApp.AppLogic;
using ToDoListApp.Domain;

namespace ToDoListApp.Infrastructure
{
    public class ToDoListRepository : IToDoListRepository
    {
        private readonly ToDoListContext _toDoListContext;

        public ToDoListRepository(ToDoListContext toDoListContext)
        {
            _toDoListContext = toDoListContext;
        }
        public void AddItemToExistingList(Guid listId, string itemDescription)
        {
            var item = ToDoItem.CreateNew(itemDescription);

            var list = _toDoListContext.ToDoLists
                .Include(l => l.Items)
                .FirstOrDefault(l => l.Id == listId);
           
            if (list == null)
            {
                throw new ArgumentException("List not found.");
            }

            list.Items.Add(item);
            var item2 = _toDoListContext.Set<ToDoItem>().FirstOrDefault(i => i.Id == item.Id);
            Console.WriteLine(item2.Description);
            //Console.WriteLine(string.Join(", ", list.Items.Select(i => i.Description)));
            //_toDoListContext.SaveChanges();

        }

        public ToDoList AddNew(string title)
        {
            var toDoList = ToDoList.CreateNew(title);
            _toDoListContext.ToDoLists.Add(toDoList);
            _toDoListContext.SaveChanges();
            return toDoList;
        }

        public IList<ToDoList> Find(string? titleFilter)
        {
            return _toDoListContext.ToDoLists
                .Where(i => string.IsNullOrEmpty(titleFilter) || i.Title.Contains(titleFilter))
                .ToList();
        }

        public ToDoList? GetById(Guid id)
        {
            return _toDoListContext.ToDoLists
                .Include(list => list.Items) 
                .FirstOrDefault(list => list.Id == id);
        }
    }
}
