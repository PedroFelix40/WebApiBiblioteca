using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApiBiblioTech.Domains
{
    [Table("Generos")]
    public class Generos
    {
        // primary key definindo o genero
        [Key]
        public Guid IDGenero { get; set; } = Guid.NewGuid();

        // column identificando o título do tipo de usuário
        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "Genero é obrigatório!")]
        public string? TituloGenero { get; set; } 
    }
}
