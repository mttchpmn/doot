using System;
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
            try
            {
                var result = _todoService.GetTodo(GetUserId(), id);
                
                return result.Successful ? Ok(result) : NotFound(result);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAllTodos()
        {
            try
            {
                var result = _todoService.GetAllTodos(GetUserId());
                
                return Ok(result);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        [HttpPost]
        public IActionResult CreateTodo(CreateTodoDto input)
        {
            try
            {
                // TODO - Validate request body
                var result = _todoService.CreateTodo(GetUserId(), input);
                var uri = $"http://api.doot.cyberwizard.io/todo/{result.Data.Id}"; // TODO - refactor into function
                
                return Created(uri, result);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        [HttpPut]
        public IActionResult UpdateTodo(UpdateTodoDto input)
        {
            try
            {
                var result = _todoService.UpdateTodo(GetUserId(), input);
                
                return Ok(result);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        [HttpPatch]
        [Route("complete/{id:int}")]
        public IActionResult CompleteTodo(int id)
        {
            try
            {
                var result = _todoService.CompleteTodo(GetUserId(), id);
                
                return Ok(result);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteTodo(int id)
        {
            try
            {
                var result = _todoService.DeleteTodo(GetUserId(), id);
                
                return NoContent();
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        private string GetUserId() => this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
    }
}