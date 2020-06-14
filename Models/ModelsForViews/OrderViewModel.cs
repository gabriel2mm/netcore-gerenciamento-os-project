using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GDR.Models.ModelsForViews
{
    public class OrderViewModel
    {
        [Display(Name = "Usuário")]
        [Required(ErrorMessage = "O campo usuário é necessário")]
        public String User { get; set; }

        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "O campo descrição é necessário")]
        public String Description { get; set; }
        public DateTime Created { get; set; }

        [Display(Name = "Requisição")]
        [Required(ErrorMessage = "O campo usuário é necessário")]
        public String Request { get; set; }

        [Display(Name = "Anexo")]
        public IFormFile Attachment { get; set; }
    }
}
