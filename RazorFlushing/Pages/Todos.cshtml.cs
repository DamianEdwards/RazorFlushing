using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorFlushing.Models;
using RazorFlushing.Services;

namespace RazorFlushing.Pages
{
    public class TodosModel : PageModel
    {
        private readonly TodoService _todos;

        public TodosModel(TodoService todos)
        {
            _todos = todos;
        }

        [BindProperty(SupportsGet = true)]
        public int? UserId { get; set; }

        public IEnumerable<Todo> Todos { get; set; }

        public async Task OnGet()
        {
            Todos = await _todos.GetTodosAsync(UserId);
        }
    }
}