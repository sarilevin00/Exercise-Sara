using Microsoft.EntityFrameworkCore;

namespace ContactFormApi.Data
{
    public class ContactFormDbContext : DbContext
    {
        public ContactFormDbContext(DbContextOptions<ContactFormDbContext> options) : base(options)
        {
        }

        public DbSet<ContactForm> ContactForms { get; set; }
    }
}