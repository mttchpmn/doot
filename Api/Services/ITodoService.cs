using System.Collections.Generic;
using Api.Models;

namespace Api.Services
{
    public interface ITodoService
    {
        Todo GetTodoItem(int id);
        IReadOnlyList<Todo> GetAllTodos();
        Todo CreateTodo(Todo input);
        Todo EditTodo(Todo input);
        Todo DeleteTodo(Todo input);
    }
}