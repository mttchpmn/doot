using System;
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

        public ServiceResponse<GetTodoDto> GetTodo(string userId, int id)
        {
            // TODO - Use async method
            var todo = GetTodoById(userId, id);

            return new ServiceResponse<GetTodoDto> {Data = todo.ToOutputDto(), Message = "Fetched TODO successfully"};
        }

        public ServiceResponse<IReadOnlyList<GetTodoDto>> GetAllTodos(string userId)
        {
            // TODO - Use async methods (ToListAsync())
            var todos = _context.Todos.Where(x => x.UserId == userId).ToList();
            var data = todos.Select(x => x.ToOutputDto()).ToList();

            return new ServiceResponse<IReadOnlyList<GetTodoDto>> {Data = data, Message = "Fetched TODOs successfully"};
        }

        public ServiceResponse<GetTodoDto> CreateTodo(string userId, CreateTodoDto createTodo)
        {
            // TODO - Use async methods
            var todo = createTodo.ToDatabaseTodo(userId);
            _context.Todos.Add(todo);
            _context.SaveChanges();

            return new ServiceResponse<GetTodoDto> {Data = todo.ToOutputDto(), Message = "Created TODO successfully"};
        }

        public ServiceResponse<GetTodoDto> CompleteTodo(string userId, int id)
        {
            // TODO - Use async methods
            var todo = GetTodoById(userId, id);
            todo.Completed = true;
            _context.Todos.Update(todo);
            _context.SaveChanges();

            return new ServiceResponse<GetTodoDto> {Data = todo.ToOutputDto(), Message = "Completed TODO successfully"};
        }

        public ServiceResponse<GetTodoDto> UpdateTodo(string userId, UpdateTodoDto input)
        {
            // TODO - Use async methods
            var todo = GetTodoById(userId, input.Id);
            todo.Title = input.Title;
            todo.Description = input.Description;
            todo.Completed = input.Completed;

            _context.Todos.Update(todo);
            _context.SaveChanges();

            return new ServiceResponse<GetTodoDto> {Data = todo.ToOutputDto(), Message = "Updated TODO successfully"};
        }

        public ServiceResponse<GetTodoDto> DeleteTodo(string userId, int id)
        {
            // TODO - Use async methods
            var todo = GetTodoById(userId, id);
            _context.Todos.Remove(todo);
            _context.SaveChanges();

            return new ServiceResponse<GetTodoDto> {Data = todo.ToOutputDto(), Message = "Deleted TODO successfully"};
        }

        private Todo GetTodoById(string userId, int id)
        {
            return _context.Todos.FirstOrDefault(x => x.UserId == userId && x.Id == id);
        }
    }
}