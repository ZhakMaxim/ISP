using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253504_Zhak.Persistense.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Author> Projects { get; set; }
        public DbSet<Book> ProjectTasks { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
