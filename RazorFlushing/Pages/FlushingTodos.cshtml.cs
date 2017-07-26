using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorFlushing.Services;
using RazorFlushing.Models;

namespace RazorFlushing.Pages
{
    public class FlushingModel : PageModel
    {
        private readonly TodoService _todos;

        public FlushingModel(TodoService todos)
        {
            _todos = todos;
        }

        [BindProperty(SupportsGet = true)]
        public int? UserId { get; set; }

        public void OnGet()
        {
            
        }

        public Task<IEnumerable<Todo>> GetTodos() => _todos.GetTodosAsync(UserId);
    }
}