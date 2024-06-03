using Microsoft.EntityFrameworkCore;
using WebApiBiblioTech.Domains;

namespace WebApiBiblioTech.Contexts
{
    public class BiblioTechContext : DbContext
    {
        public BiblioTechContext()
        {
            
        }

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

        string StringConexaoSenai = "Data Source=DESKTOP-1CNOHAQ\\SQLEXPRESS; initial catalog=BiblioTech; TrustServerCertificate=true; user Id = sa; pwd=Senai@134";
        string StringConexaoCasa = "Data Source=DESKTOP-1CNOHAQ\\SQLEXPRESS; initial catalog=BiblioTech; TrustServerCertificate=true; user Id = sa; pwd=2502";

        // StringConexao
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
         => optionsBuilder.UseSqlServer(StringConexaoCasa);

    }
}
