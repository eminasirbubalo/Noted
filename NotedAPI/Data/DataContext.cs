using Microsoft.EntityFrameworkCore;
using NotedAPI.Models;
using static System.Net.Mime.MediaTypeNames;

namespace NotedAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Note> Notes { get; set; }
    }
}
