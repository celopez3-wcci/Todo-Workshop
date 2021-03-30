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

        // PUT: api/Todo/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public Todo PutTodo(int id, Todo todo)
        {
            if (id != todo.Id)
            {
                return null;
            }

            todoRepo.Update(todo);

            return todo;
           
        }

        // POST: api/Todo
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public Owner PostTodo([FromBody]Todo todo)
        {
            todo.DueBy = todo.CreatedOn.AddDays(5);

            todoRepo.Create(todo);

            return todoRepo.GetOwnerByTodoId(todo.Id);
        }

        // DELETE: api/Todo/5
        [HttpDelete("{id}")]
        public string DeleteTodo(int id)
        {
            var todo = todoRepo.GetById(id);

            todoRepo.Delete(todo);

            return "Deleted item successfully";
        }

        //private bool TodoExists(int id)
        //{
        //    return _context.Todos.Any(e => e.Id == id);
        //}
    }
}
