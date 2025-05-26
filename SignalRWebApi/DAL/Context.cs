using Microsoft.EntityFrameworkCore;

namespace SignalRWebApi.DAL
{
    public class Context : DbContext
    {
        public Context(DbContextOptions options) : base(options)
        {
        }
       public DbSet<Visitor> Visitors { get; set; }   
    }
}
