using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using todos;
using todos.Models;
using todos.Repositories;

namespace todos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        IRepository<Todo> todoRepo;

        public TodoController(IRepository<Todo> todoRepo)
        {
            this.todoRepo = todoRepo;
        }

        // GET: api/Todo
        [HttpGet]
        public IEnumerable<Todo> GetTodos()
        {
            return todoRepo.GetAll();
        }

        // GET: api/Todo/5
        [HttpGet("{id}")]
        public Todo GetTodo(int id)
        {
            var todo = todoRepo.GetById(id);

            return todo;
        }

        //// PUT: api/Todo/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for
        //// more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutTodo(int id, Todo todo)
        //{
        //    if (id != todo.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(todo).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!TodoExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // POST: api/Todo
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public Todo PostTodo([FromBody]Todo todo)
        {
            todoRepo.Create(todo);

            return todo;
        }

        //// DELETE: api/Todo/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<Todo>> DeleteTodo(int id)
        //{
        //    var todo = await _context.Todos.FindAsync(id);
        //    if (todo == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Todos.Remove(todo);
        //    await _context.SaveChangesAsync();

        //    return todo;
        //}

        //private bool TodoExists(int id)
        //{
        //    return _context.Todos.Any(e => e.Id == id);
        //}
    }
}
