using GDR.Enumerators;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GDR.Models.ModelsForViews
{
    public class RequestViewModel
    {
        public Guid Id { get; set; }

        [Display(Name = "Usuários")]
        public String UserId { get; set; }

        [Display(Name = "Tipo")]
        [Required(ErrorMessage = "O campo tipo é necessário")]
        public Types Type { get; set; }

        [Display(Name = "Equipamento")]
        [Required(ErrorMessage = "O campo Equipamento é necessário")]
        [Description("Preencha com o nome do equipamento ou peça a ser substítuido")]
        public String Equipament { get; set; }

        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "O campo Descrição é necessário")]
        public String Description { get; set; }
    }
}
