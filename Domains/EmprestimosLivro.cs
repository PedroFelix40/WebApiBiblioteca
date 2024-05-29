using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiBiblioteca.Domains
{
    [Table("EmprestimosLivro")]
    public class EmprestimosLivro
    {
        [Key]
        public Guid IDEmprestimoLivro { get; set; } = Guid.NewGuid();

        // Atributos
        [Column(TypeName = "VARCHAR(60)")]
        [Required(ErrorMessage = "A situação é obrigatório!")]    
        public string? Situacao { get; set; }

        [Column(TypeName = "DATE")]
        [Required(ErrorMessage = "A data da consulta é obrigatório!")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataDevolucao { get; set; }

        // FK Livro
        [Required(ErrorMessage = "O tipo do usuário é obrigatório!")]
        public Guid IDUsuario { get; set; }


        [ForeignKey("IDUsuario")] // plural = entidade / singular = atributo
        public Usuarios? Usuario { get; set; }


    }
}
