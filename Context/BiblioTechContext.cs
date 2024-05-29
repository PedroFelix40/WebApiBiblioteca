using Microsoft.EntityFrameworkCore;
using WebApiBiblioteca.Domains;

namespace WebApiBiblioteca.Context
{
    public class BiblioTechContext : DbContext
    {

        public BiblioTechContext(){}

        public BiblioTechContext(DbContextOptions<BiblioTechContext> options)
            : base(options)
        {
        }

        public DbSet<EmprestimosLivro> EmprestimosLivro { get; set; }

        public DbSet<Generos> Generos { get; set; }

        public DbSet<Livros> Livros { get; set; }

        public DbSet<Resenhas> Resenhas { get; set; }

        public DbSet<TiposUsuario> TiposUsuario { get; set; }

        public DbSet<Usuarios> Usuarios { get; set; }


        // String de conexão
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=NOTE06-S21\\SQLEXPRESS; initial catalog=BiblioTech; TrustServerCertificate=true; user Id = sa; pwd=Senai@134");
    }
}
