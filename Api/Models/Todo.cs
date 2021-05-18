namespace Api.Models
{
    public class Todo
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Completed { get; set; }
    }

    public class GetTodoDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Completed { get; set; }
    }

    public class CreateTodoDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Completed { get; set; }
    }
    
    public class UpdateTodoDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Completed { get; set; }
    }

    public static class TodoExtensions
    {
        public static GetTodoDto ToOutputDto(this Todo todo) => new GetTodoDto
            {Id = todo.Id, Title = todo.Title, Description = todo.Description, Completed = todo.Completed};

        public static Todo ToDatabaseTodo(this UpdateTodoDto dto, string userId) => new Todo
            {Id = dto.Id, UserId = userId, Title = dto.Title, Description = dto.Description, Completed = dto.Completed};
        
        public static Todo ToDatabaseTodo(this CreateTodoDto dto, string userId) => new Todo
            {UserId = userId, Title = dto.Title, Description = dto.Description, Completed = dto.Completed};
    }
}