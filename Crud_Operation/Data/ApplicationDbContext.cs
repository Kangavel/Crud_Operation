using Crud_Operation.Models;
using Microsoft.EntityFrameworkCore;

namespace Crud_Operation.Data
{
    public class ApplicationDbContext : DbContext

    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

       
       public DbSet<Student> students { get; set; }
    }
}
