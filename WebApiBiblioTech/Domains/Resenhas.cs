﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using webapibibliotech.Domains;

namespace webapibibliotech.Domains
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

        [Column(TypeName = "DATE")]
        [Required(ErrorMessage = "A data do comentário é obrigatória!")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataComentario { get; set; }

        [Required(ErrorMessage = "Usuário é obrigatório!")]
        public Guid IDUsuario { get; set; }

        [ForeignKey("IDUsuario")]
        public Usuarios? Usuario { get; set; }

        [Required(ErrorMessage = "Livro é obrigatório!")]
        public Guid IDLivro { get; set; }

        [ForeignKey("IDLivro")]
        public Livros? Livro { get; set; }

    }
}