using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace webapibibliotech.Domains
{
    [Table("Generos")]
    public class Generos
    {
        [Key]
        public Guid IDGenero { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "Gênero é obrigatório!")]
        public string? TituloGenero { get; set; }
    }
}