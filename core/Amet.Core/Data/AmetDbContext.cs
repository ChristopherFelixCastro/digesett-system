using Microsoft.EntityFrameworkCore;
using Amet.Core.Models;

namespace Amet.Core.Data
{
    public class AmetDbContext : DbContext
    {
        public AmetDbContext(DbContextOptions<AmetDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Conductor> Conductores { get; set; }
        public DbSet<TipoInfraccion> TiposInfraccion { get; set; }
        public DbSet<Acta> Actas { get; set; }
        public DbSet<Canodromo> Canodromos { get; set; }
        public DbSet<Pago> Pagos { get; set; }
        public DbSet<Impugnacion> Impugnaciones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Acta>()
                .HasOne(a => a.Agente)
                .WithMany()
                .HasForeignKey(a => a.AgenteId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Canodromo>()
                .HasOne(c => c.AdminIngreso)
                .WithMany()
                .HasForeignKey(c => c.AdminIngresoId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Canodromo>()
                .HasOne(c => c.AdminSalida)
                .WithMany()
                .HasForeignKey(c => c.AdminSalidaId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Pago>()
                .HasOne(p => p.Cajero)
                .WithMany()
                .HasForeignKey(p => p.CajeroId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Impugnacion>()
                .HasOne(i => i.Fiscal)
                .WithMany()
                .HasForeignKey(i => i.FiscalId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}