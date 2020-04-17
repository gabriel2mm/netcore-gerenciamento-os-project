using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GDR.Models.ModelsForViews
{
    public class RoleViewModel
    {
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string Name { get; set; }
    }
}
