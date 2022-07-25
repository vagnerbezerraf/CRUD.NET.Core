using CRUD.Net.Core.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Net.Core.DataLayer.Context
{
    public class CRUDContext : DbContext
    {
        public CRUDContext(DbContextOptions<CRUDContext> options) : base(options)
        {
        }

        public DbSet<Evento> Evento { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CRUDContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableDetailedErrors()
                .EnableServiceProviderCaching()
                .EnableSensitiveDataLogging();

            base.OnConfiguring(optionsBuilder);
        }

    }
}
