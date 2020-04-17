using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GDR.Models.ModelsForViews
{
    public class RegisterViewModel
    {
        [Display(Name="Nome")]
        [MaxLength(25, ErrorMessage = "Este campo deve conter no máximo 25 caracteres")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string First_Name { get; set; }

        [Display(Name = "Sobrenome")]
        [MaxLength(50, ErrorMessage = "Este campo deve conter no máximo 50 caracteres")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string Last_name { get; set; }

        [Display(Name = "E-mail")]
        [EmailAddress(ErrorMessage = "Informe um E-mail válido")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string Email { get; set; }

        [Display(Name = "Usuário")]
        [MaxLength(15, ErrorMessage ="Este campo deve conter no máximo 15 caracteres")]
        [MinLength(6, ErrorMessage = "Este campo deve conter no mínimo 6 caracteres")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string Login { get; set; }

        [Display(Name = "Senha")]
        [MaxLength(15, ErrorMessage = "Este campo deve conter no máximo 15 caracteres")]
        [MinLength(8, ErrorMessage = "Este campo deve conter no mínimo 8 caracteres")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string Password { get; set; }

        [Display(Name = "Confirme sua senha")]
        [Required(ErrorMessage ="Este campo é obrigatório")]
        [Compare("Password", ErrorMessage = "As senhas não conferem")]
        public string PasswordConfirm { get; set; }
    }
}
