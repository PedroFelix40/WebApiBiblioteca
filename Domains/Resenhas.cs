using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiBiblioteca.Domains
{
    [Table("Resenhas")]
    public class Resenhas
    {
        [Key]
        public Guid IDResenha { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(200)")]
        [Required(ErrorMessage = "Descrição da resenha é obrigatória!")]
        public string? Descricao { get; set; }

        [Column(TypeName = "BIT")]
        [Required]
        public bool Exibe { get; set; }

        // ref Usuário
        [Required(ErrorMessage = "Usuário obrigatório!")]
        public Guid IDUsuario { get; set; }

        [ForeignKey("IDUsuario")]
        public Usuarios? Usuario { get; set; } // definição "usuario" sei la por que


        //ref Livro
        [Required(ErrorMessage = "Livro obrigatório!")]
        public Guid IDLivro { get; set; }

        [ForeignKey("IDLivro")]
        public Livros? Livro { get; set; }

    }
}
