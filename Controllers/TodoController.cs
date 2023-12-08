using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly ILogger<TodoController> _logger;
        private readonly TodoContext     _context;

        public TodoController(ILogger<TodoController> logger, TodoContext    context)
        { 
            _logger = logger;
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<TodoItem>> PostTodoItem(TodoItem todoItem)
        {
            // Di sini tambahkan logika untuk menambahkan TodoItem ke database atau sumber data lainnya
            _context.TodoItems.Add(todoItem);
            await _context.SaveChangesAsync();

            // Sebagai contoh, kita hanya mengembalikan TodoItem yang diterima dengan respons CreatedAtAction
            return CreatedAtAction(nameof(GetTodoItem), new { id = todoItem.Id }, todoItem);
        }

        private object GetTodoItem()
        {
            throw new NotImplementedException();
        }

        // Tambahkan metode GetTodoItem yang sesuai dengan kebutuhan aplikasi Anda
        // [HttpGet("{id}", Name = "GetTodoItem")]
        // public ActionResult<TodoItem> GetTodoItem(int id)
        // {
        //     // Di sini tambahkan logika untuk mendapatkan TodoItem berdasarkan ID
        // }

        // Tambahkan metode lain yang diperlukan sesuai dengan kebutuhan aplikasi Anda
    }
}
