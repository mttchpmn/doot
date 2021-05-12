using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api
{
    public class PostgresContext : DbContext
    {
        public PostgresContext(DbContextOptions<PostgresContext> options) : base(options)
        {
        }
        public DbSet<Todo> Todos { get; set; }
    }
}