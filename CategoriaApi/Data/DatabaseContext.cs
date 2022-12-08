using CategoriaApi.Model;
using Microsoft.EntityFrameworkCore;

namespace CategoriaApi.Data
{
    public class DatabaseContext: DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> opt) : base(opt)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<SubCategoria>().
                HasOne(subCategoria => subCategoria.Categoria).
                WithMany(categoria => categoria.SubCategoria).
                HasForeignKey(subCategoria => subCategoria.CategoriaId);

            builder.Entity<Cliente>()
                .HasOne(endereco => endereco.Endereco)
                .WithMany(endereco => endereco.Cliente)
                .HasForeignKey(cliente => cliente.EnderecoId);
        }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<SubCategoria> SubCategorias { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }

    }
}
