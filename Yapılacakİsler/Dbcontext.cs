using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yapılacakİsler
{
    public class DbTodoListContext : DbContext
    {
        public DbSet<ToDoItem> ToDoItems => Set<ToDoItem>();
        
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

        public override int SaveChanges()
        {
            foreach (EntityEntry girdi in ChangeTracker.Entries())
            {
                if (girdi.State == EntityState.Deleted && girdi.Entity is ToDoItem)
                {
                    ToDoItem oge = (ToDoItem)girdi.Entity;
                    oge.Deleted = true;
                    girdi.State = EntityState.Modified;
                }

            }

            return base.SaveChanges();
        }
    }
}
