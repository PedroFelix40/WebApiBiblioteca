using Microsoft.EntityFrameworkCore;
using webapibibliotech.Domains;

namespace webapibibliotech.Contexts
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

        //private readonly string StringConexao = "Server=tcp:bibliotechserv.database.windows.net,1433;Initial Catalog=bibliotechdatabase;Persist Security Info=False;User ID=bibliotechlog;Password=Senai@134;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=30;";
        //private readonly string StringConexao = "Data Source=DESKTOP-1CNOHAQ\\SQLEXPRESS; initial catalog=BiblioTech; TrustServerCertificate=true; user Id = sa; pwd=2502";
        private readonly string StringConexao = "Data Source=NOTE06-S21\\SQLEXPRESS; initial catalog=BiblioTech; TrustServerCertificate=true; user Id = sa; pwd=Senai@134";

        // StringConexao
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
         => optionsBuilder.UseSqlServer(StringConexao);

    }
}
