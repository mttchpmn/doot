using System.Collections.Generic;
using Api.Models;

namespace Api.Services
{
    public interface ITodoService
    {
        GetTodoDto GetTodo(string userId, int id);
        IReadOnlyList<GetTodoDto> GetAllTodos(string userId);
        GetTodoDto CreateTodo(string userId, CreateTodoDto createTodo);
        GetTodoDto UpdateTodo(string userId, UpdateTodoDto input);
        GetTodoDto CompleteTodo(string userId, int id);
        GetTodoDto DeleteTodo(string userId, int id);
    }
}