using Microsoft.EntityFrameworkCore;
using TraversalWebApi.Entities;

namespace TraversalWebApi.DAL.Context
{
    public class VisitorContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-3ADO5MC\\SQLEXPRESS; initial catalog=TraversalWebApi; integrated security=true; ");
            
        }


        public DbSet<Visitor> Visitors { get; set; }
    }
}
