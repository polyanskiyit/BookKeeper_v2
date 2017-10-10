using System.Data.Entity;

namespace BookKeeper.Models
{
    public class BookContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
    }
}