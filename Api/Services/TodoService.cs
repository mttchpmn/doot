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

        public GetTodoDto GetTodo(string userId, int id)
        {
            // TODO - Use async method
            var todo = GetTodoById(userId, id);
            
            return todo.ToOutputDto();
        }

        public IReadOnlyList<GetTodoDto> GetAllTodos(string userId)
        {
            // TODO - Use async methods (ToListAsync())
            var todos =  _context.Todos.ToList();

            return todos.Select(x => x.ToOutputDto()).ToList();
        }

        public GetTodoDto CreateTodo(string userId, CreateTodoDto createTodo)
        {
            // TODO - Use async methods
            var todo = createTodo.ToDatabaseTodo(userId);
            _context.Todos.Add(todo);
            _context.SaveChanges();

            return todo.ToOutputDto();
        }

        public GetTodoDto CompleteTodo(string userId, int id)
        {
            // TODO - Use async methods
            var todo = GetTodoById(userId, id);
            todo.Completed = true;
            _context.Todos.Update(todo);
            _context.SaveChanges();

            return todo.ToOutputDto();
        }

        public GetTodoDto UpdateTodo(string userId, UpdateTodoDto input)
        {
            // TODO - Use async methods
            var todo = GetTodoById(userId, input.Id);
            todo.Title = input.Title;
            todo.Description = input.Description;
            todo.Completed = input.Completed;

            _context.Todos.Update(todo);
            _context.SaveChanges();

            return todo.ToOutputDto();
        }

        public GetTodoDto DeleteTodo(string userId, int id)
        {
            // TODO - Use async methods
            var todo = GetTodoById(userId, id);
            _context.Todos.Remove(todo);
            _context.SaveChanges();

            return todo.ToOutputDto();
        }

        private Todo GetTodoById(string userId, int id) => _context.Todos.FirstOrDefault(x => x.UserId == userId && x.Id == id);
    }
}