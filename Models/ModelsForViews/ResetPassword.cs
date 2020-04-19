using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GDR.Models.ModelsForViews
{
    public class ResetPassword
    {
        public string Id { get; set; }
        [Display(Name = "Senha atual")]
        [MaxLength(15, ErrorMessage = "Este campo deve conter no máximo 15 caracteres")]
        [MinLength(8, ErrorMessage = "Este campo deve conter no mínimo 8 caracteres")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string CurrentPassword { get; set; }

        [Display(Name = "Senha")]
        [MaxLength(15, ErrorMessage = "Este campo deve conter no máximo 15 caracteres")]
        [MinLength(8, ErrorMessage = "Este campo deve conter no mínimo 8 caracteres")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string Password { get; set; }

        [Display(Name = "Confirme sua senha")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        [Compare("Password", ErrorMessage = "As senhas não conferem")]
        public string PasswordConfirm { get; set; }
    }
}
