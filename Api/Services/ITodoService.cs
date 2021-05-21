using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Models;

namespace Api.Services
{
    public interface ITodoService
    {
        ServiceResponse<GetTodoDto> GetTodo(string userId, int id);
        ServiceResponse<IReadOnlyList<GetTodoDto>> GetAllTodos(string userId);
        ServiceResponse<GetTodoDto>CreateTodo(string userId, CreateTodoDto createTodo);
        ServiceResponse<GetTodoDto>UpdateTodo(string userId, UpdateTodoDto input);
        ServiceResponse<GetTodoDto>CompleteTodo(string userId, int id);
        ServiceResponse<GetTodoDto>DeleteTodo(string userId, int id);
    }
}