using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace webapibibliotech.ViewModel
{
    public class UsuarioViewModel
    {
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Senha { get; set; }
        public int? CodRecupSenha { get; set; }
        public Guid IdTipoUsuario { get; set; }

        [NotMapped]
        [JsonIgnore]
        public IFormFile? Arquivo { get; set; }
        public string? Foto { get; set; }

    }
}
