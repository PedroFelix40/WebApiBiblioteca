

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiBiblioteca.Domains
{
    [Table("TiposUsuario")]
    public class TiposUsuario
    {
        // primary key definindo o tipo de usuário
        [Key]
        public Guid IDTipoUsuario { get; set; } = Guid.NewGuid();

        // column identificando o título do tipo de usuário
        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "Tipo de usuário obrigatório!")]
        public string? TituloTipoUsuario { get; set; }
    }
}
