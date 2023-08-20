using Microsoft.EntityFrameworkCore;

namespace testauthcookiegoogle.Models
{
    public class dbcontext:DbContext
    {
        public dbcontext(DbContextOptions<dbcontext> options) : base(options)
        {

        }
        //public DbSet<Account> accounts { get; set; }    
        public DbSet<crud> cruds { get; set; }    
    }
}
