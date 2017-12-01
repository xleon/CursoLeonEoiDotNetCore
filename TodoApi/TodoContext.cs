using Microsoft.EntityFrameworkCore;
using TodoApi.Model;

namespace TodoApi
{
    public class TodoContext : DbContext
    {
        public DbSet<TodoItem> Items { get; set; }
        public DbSet<TodoList> Lists { get; set; }

        public TodoContext(DbContextOptions<TodoContext> options)
            : base(options) { }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlite("Data Source=todo.db");
        //    base.OnConfiguring(optionsBuilder);
        //}

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<TodoList>()
        //       .HasMany(list => list.Items)
        //       .WithOne(item => item.TodoList);

        //    base.OnModelCreating(modelBuilder);
        //}
    }
}
