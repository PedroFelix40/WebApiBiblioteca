using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using webapibibliotech.Domains;

namespace webapibibliotech.Domains
{
    [Table("Livros")]
    public class Livros
    {
        [Key]
        public Guid IDLivro { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(60)")]
        [Required(ErrorMessage = "O titulo do livro é obrigatória!")]
        public string? Titulo { get; set; }

        [Column(TypeName = "VARCHAR(60)")]
        [Required(ErrorMessage = "O autor do livro é obrigatória!")]
        public string? Autor { get; set; }

        [Column(TypeName = "VARCHAR(60)")]
        [Required(ErrorMessage = "O ano do livro é obrigatória!")]
        public string? Ano { get; set; }

        [Column(TypeName = "VARCHAR(60)")]
        [Required(ErrorMessage = "A editora do livro é obrigatória!")]
        public string? Editora { get; set; }

        [Column(TypeName = "VARCHAR(60)")]
        [Required(ErrorMessage = "O ISBN do livro é obrigatório!")]
        [StringLength(60, MinimumLength = 10, ErrorMessage = "O ISBN deve conter 13 dígitos!")]
        public string? ISBN { get; set; }

        [Column(TypeName = "VARCHAR(60)")]
        [Required(ErrorMessage = "O Situacao do livro é obrigatória!")]
        public string? SituacaoLivro { get; set; }


        public string? Capa { get; set; }

        // FK
        [Required(ErrorMessage = "O gênero do livro é obrigatório!")]
        public Guid IDGenero { get; set; }

        [ForeignKey("IDGenero")]
        public Generos? Genero { get; set; }

    }
}