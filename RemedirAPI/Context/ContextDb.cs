using Microsoft.EntityFrameworkCore;
using RemedirAPI.Models;
using System.Reflection.Emit;


namespace RemedirAPI.Context
{
    public class ContextDb : DbContext
    {
    public DbSet<HistoricoDeDoador>? historicoDeDoador { get; set; }
    public DbSet<Endereco>? endereco { get; set; }
    public ContextDb(DbContextOptions<ContextDb> options) : base(options)
    {

    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}

}

