﻿using System.ComponentModel.DataAnnotations;

namespace webapibibliotech.ViewModel
{
    public class AlterarSenhaViewModel
    {
        [Required(ErrorMessage = "Informe a nova senha do usuário")]
        public string? SenhaNova { get; set; }
    }
}
