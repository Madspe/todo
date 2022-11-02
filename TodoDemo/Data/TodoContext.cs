using Microsoft.EntityFrameworkCore;
using TodoDemo.Models;

namespace TodoDemo.Data
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options)
            : base(options)
        {

        }

        public DbSet<Todo> Todos { get; set; }

        public DbSet<TodoDemo.Models.TodoType> TodoType { get; set; }
    }
}
