using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GDR.Models.ModelsForViews
{
    public class SchedulingViewModel
    {
        
        public Guid Id { get; set; }
        [Display(Name = "Data de agendamento")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        [Required(ErrorMessage = "A data de agendamento é obrigatória")]
        public DateTime Agendamento { get; set; }
    }
}
