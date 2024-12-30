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
    public class ToDoItemRepository : IToDoItemRepository
    {
        private readonly ToDoListContext _toDoListContext;

        public ToDoItemRepository(ToDoListContext toDoListContext)
        {
            _toDoListContext = toDoListContext;
        }

        public int GetTotalOfItemsThatAreNotDone()
        {
            return _toDoListContext.Set<ToDoItem>().Where(t => t.IsDone == false).Count();
        }

        public ToDoItem Update(Guid id, bool isDone)
        {
            var item = _toDoListContext.Set<ToDoItem>().FirstOrDefault(i => i.Id == id);
            if (item != null)
            {
                item.IsDone = isDone;
                _toDoListContext.Update(item);
            }
            
            
            _toDoListContext.SaveChanges();
            return item;
        }
    }
}
