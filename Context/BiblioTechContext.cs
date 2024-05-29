using Microsoft.EntityFrameworkCore;

namespace WebApiBiblioteca.Context
{
    public class BiblioTechContext : DbContext
    {

        public BiblioTechContext(){}

        public BiblioTechContext(DbContextOptions<BiblioTechContext> options)
            : base(options)
        {
            
        }


        // String de conexão
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=NOTE06-S21\\SQLEXPRESS; initial catalog=BiblioTech; TrustServerCertificate=true; user Id = sa; pwd=Senai@134");
    }
}
