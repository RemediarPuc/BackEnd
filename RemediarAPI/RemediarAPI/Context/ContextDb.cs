using Microsoft.EntityFrameworkCore;
using RemediarAPI.Models;
using System.Reflection.Emit;

namespace RemediarAPI.Context
{
    public class ContextDb : DbContext
    {
        public DbSet<Doacao> Doacoes { get; set; }
        public DbSet<Medicamento> Medicamentos { get; set; }
        public DbSet<MedicamentoDescartado> MedicamentosDescartados { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public ContextDb(DbContextOptions<ContextDb> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Pedido>()
                .Property(e => e.statusPedido)
                .HasConversion(
                    v => v.ToString(),
                    v => (Status)Enum.Parse(typeof(Status), v)
                );

            modelBuilder.Entity<Doacao>()
               .Property(e => e.statusDoacao)
               .HasConversion(
                   v => v.ToString(),
                   v => (Status)Enum.Parse(typeof(Status), v)
               );

            modelBuilder.Entity<Usuario>()
                .Property(e => e.tipoUsuario)
                .HasConversion(
                    v => v.ToString(),
                    v => (TipoUsuario)Enum.Parse(typeof(TipoUsuario), v)
                );

        }
    }
}
