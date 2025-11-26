using Fiap.Agnello.Models;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Agnello.Data
{
    public class DatabaseContext : DbContext
    {

        public virtual DbSet<VinhoModel> Vinhos { get; set; }

        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }

        protected DatabaseContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VinhoModel>(entity =>
            {
                entity.ToTable("Vinhos");
                entity.HasKey(e => e.VinhoId);
                entity.Property(e => e.Nome).IsRequired();
                entity.Property(e => e.Tipo).IsRequired();
                entity.Property(e => e.Preco).IsRequired();
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
