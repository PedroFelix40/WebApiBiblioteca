using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;


namespace webapibibliotech.ViewModel
{
    public class UsuarioFotoViewModel
    {
        [NotMapped]
        [JsonIgnore]
        public IFormFile? Arquivo { get; set; }
        public string? Foto { get; set; }
    }
}
