using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using ToDoApp.Models;

namespace ToDoApp.Pages
{
    public class IndexModel : PageModel
    {
        // Simple in-memory list to store tasks (reset on restart)
        private static List<ToDoItem> tasks = new List<ToDoItem>();
        private static int nextId = 1;

        [BindProperty]
        public string NewTask { get; set; }

        public List<ToDoItem> Tasks => tasks;

        public void OnGet()
        {
        }

        public IActionResult OnPostAdd()
        {
            if (!string.IsNullOrWhiteSpace(NewTask))
            {
                tasks.Add(new ToDoItem { Id = nextId++, Task = NewTask, IsDone = false });
            }
            return RedirectToPage();
        }

        public IActionResult OnPostToggleDone(int id)
        {
            var task = tasks.FirstOrDefault(t => t.Id == id);
            if (task != null)
            {
                task.IsDone = !task.IsDone;
            }
            return RedirectToPage();
        }

        public IActionResult OnPostDelete(int id)
        {
            tasks.RemoveAll(t => t.Id == id);
            return RedirectToPage();
        }
    }
}
