using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GDR.Models.ModelsForViews
{
    public class LoginViewModel
    {
        [Display(Name = "Usuário")]
        [MaxLength(15, ErrorMessage = "Este campo deve conter no máximo 15 caracteres")]
        [MinLength(6, ErrorMessage = "Este campo deve conter no mínimo 6 caracteres")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string Login { get; set; }

        [Display(Name = "Senha")]
        [MaxLength(15, ErrorMessage = "Este campo deve conter no máximo 15 caracteres")]
        [MinLength(8, ErrorMessage = "Este campo deve conter no mínimo 8 caracteres")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Lembrar de mim ?")]
        public bool RememberMe { get; set; }

        public string returnUrl { get; set; }
    }
}
