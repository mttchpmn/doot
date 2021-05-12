using Api.Models;
using Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly ITodoService _todoService;

        public TodoController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetTodo(int id)
        {
            return Ok("Hi Mum");
        }

        [HttpGet]
        public IActionResult GetAllTodos()
        {
            var result = _todoService.GetAllTodos();
            return Ok(result);
        }
        
        [HttpPost]
        public IActionResult CreateTodo(Todo input)
        {
            var result = _todoService.CreateTodo(input);
            return Ok(result);
        }
        
        [HttpPut]
        public IActionResult UpdateTodo(Todo input)
        {
            var result = _todoService.UpdateTodo(input);
            return Ok(result);
        }
        
        [HttpDelete]
        public IActionResult DeleteTodo(int id)
        {
            var result = _todoService.DeleteTodo(id);
            return Ok(result);
        }
        
        
    }
}