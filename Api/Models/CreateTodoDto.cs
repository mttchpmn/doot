namespace Api.Models
{
    public class CreateTodoDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Completed { get; set; }
    }
}