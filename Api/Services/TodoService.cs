using System.Collections.Generic;
using System.Linq;
using Api.Models;

namespace Api.Services
{
    public class TodoService : ITodoService
    {
        private readonly PostgresContext _context;

        public TodoService(PostgresContext context)
        {
            _context = context;
        }
        public Todo GetTodo(int id)
        {
            // TODO - Use async method
            return _context.Todos.FirstOrDefault(x => x.Id == id);
        }

        public IReadOnlyList<Todo> GetAllTodos()
        {
            // TODO - Use async methods (ToListAsync())
            return _context.Todos.ToList();
        }

        public Todo CreateTodo(Todo input)
        {
            // TODO - Use async methods
            _context.Todos.Add(input);
            _context.SaveChanges();

            return input;
        }

        public Todo UpdateTodo(Todo input)
        {
            // TODO - Use async methods
            var todo = GetTodoById(input.Id);
            todo.Title = input.Title;
            todo.Description = input.Description;
            todo.Completed = input.Completed;

            _context.Todos.Add(todo);
            _context.SaveChanges();

            return todo;
        }

        public Todo DeleteTodo(int id)
        {
            // TODO - Use async methods
            var todo = GetTodoById(id);
            _context.Todos.Remove(todo);
            _context.SaveChanges();

            return todo;
        }

        private Todo GetTodoById(int id) => _context.Todos.FirstOrDefault(x => x.Id == id);
    }
}