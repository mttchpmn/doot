using System.Collections.Generic;
using System.Linq;
using Api.Models;

namespace Api.Services
{
    public class TodoService : ITodoService
    {
        private readonly PostgresContext _postgresContext;

        public TodoService(PostgresContext postgresContext)
        {
            _postgresContext = postgresContext;
        }
        public Todo GetTodoItem(int id)
        {
            throw new System.NotImplementedException();
        }

        public IReadOnlyList<Todo> GetAllTodos()
        {
            // TODO - Use async methods (ToListAsync())
            return _postgresContext.Todos.ToList();
        }

        public Todo CreateTodo(Todo input)
        {
            // TODO - Use async methods
            _postgresContext.Todos.Add(input);
            _postgresContext.SaveChanges();

            return input;
        }

        public Todo UpdateTodo(Todo input)
        {
            throw new System.NotImplementedException();
        }

        public Todo DeleteTodo(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}