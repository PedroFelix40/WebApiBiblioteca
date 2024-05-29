﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiBiblioteca.Domains
{
        [Table("Usuarios")]
        [Index(nameof(Email), IsUnique = true)]
        public class Usuarios
        {
            [Key]
            public Guid IdUsuario { get; set; } = Guid.NewGuid();

            [Column(TypeName = "VARCHAR(100)")]
            [Required(ErrorMessage = "O Nome do usuário é obrigatório!")]
            public string? Nome { get; set; }


            [Column(TypeName = "VARCHAR(100)")]
            [Required(ErrorMessage = "O Email do usuário é obrigatório!")]
            public string? Email { get; set; }


            [Column(TypeName = "VARCHAR(60)")]
            [Required(ErrorMessage = "A senha do usuário é obrigatória!")]
            [StringLength(60, MinimumLength = 5, ErrorMessage = "A senha deve conter entre 5 e 30 caracteres.")]
            public string? Senha { get; set; }


            //referência para a entidade

            [Required(ErrorMessage = "O tipo do usuário é obrigatório!")]
            public Guid IDTipoUsuario { get; set; }


            [ForeignKey("IDTipoUsuario")] // plural = entidade / singular = atributo
            public TiposUsuario? TipoUsuario { get; set; }
        }
}