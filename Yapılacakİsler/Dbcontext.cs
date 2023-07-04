using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yapılacakİsler
{
    public class DbTodoListContext : DbContext
    {
        public DbSet<ToDoItem> ToDoItems { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ToDoItem>().HasData(
            new ToDoItem { Id = 1, Title = "Proje teklifini tamamla", Done = false },
            new ToDoItem { Id = 2, Title = "Sunum slaytlarını hazırla", Done = false },
            new ToDoItem { Id = 3, Title = "Kod değişikliklerini gözden geçir", Done = true },
            new ToDoItem { Id = 4, Title = "Takip e-postalarını gönder", Done = true }
        );
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=.\\;database=ToDoList;trusted_connection=true");
        }
    }
}
