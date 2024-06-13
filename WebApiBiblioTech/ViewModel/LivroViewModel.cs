using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;


namespace webapibibliotech.ViewModel
{
    public class LivroViewModel
    {
        public string? Titulo { get; set; }
        public string? Autor { get; set; }
        public string? Ano { get; set; }
        public string? Editora { get; set; }
        public string? ISBN { get; set; }
        public string? SituacaoLivro { get; set; }
        public Guid IDGenero { get; set; }

        [NotMapped]
        [JsonIgnore]
        public IFormFile? Arquivo { get; set; }
        public string? Capa { get; set; }
    }
}
