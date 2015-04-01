using System.Data.Entity;

namespace MvcDemo.Models
{
    public class EFDbContext : DbContext
    {
        public DbSet<Meeting> Meetings { get; set; } 
    }
}