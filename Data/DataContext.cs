using SpendBuddy.Models;
using Microsoft.EntityFrameworkCore;

namespace SpendBuddy.Data
{
    internal class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Log> Logs { get; set; }
    }
}
