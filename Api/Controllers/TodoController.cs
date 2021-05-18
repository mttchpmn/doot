using System.Security.Claims;
using Api.Models;
using Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
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
            var result = _todoService.GetTodo(GetUserId(), id);
            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetAllTodos()
        {
            var result = _todoService.GetAllTodos(GetUserId());
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateTodo(CreateTodoDto input)
        {
            var result = _todoService.CreateTodo(GetUserId(), input);
            return Ok(result);
        }

        [HttpPut]
        public IActionResult UpdateTodo(UpdateTodoDto input)
        {
            var result = _todoService.UpdateTodo(GetUserId(), input);
            return Ok(result);
        }

        [HttpPatch]
        [Route("complete/{id:int}")]
        public IActionResult CompleteTodo(int id)
        {
            var result = _todoService.CompleteTodo(GetUserId(), id);
            return Ok(result);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteTodo(int id)
        {
            var result = _todoService.DeleteTodo(GetUserId(), id);
            return Ok(result);
        }

        private string GetUserId() => this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
    }
}