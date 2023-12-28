using businessUnit.EFCore;
using Microsoft.EntityFrameworkCore;

namespace businessUnit.component.EfCore

{
    public class EF_DataContext : DbContext
    {
        public EF_DataContext(DbContextOptions<EF_DataContext> options) : base(options) { } // adding constructor and linking the dbcontext 
                                                                                            // this is ASP.NET dependency injection support
        public DbSet<businessUnits> businessUnits { get; set; }
    }
}
