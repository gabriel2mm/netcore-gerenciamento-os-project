using GDR.Enumerators;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GDR.Models
{
    public class Request
    {
        [Key]
        public Guid Id { get; set; }

        [Column("Users")]
        [Display(Name = "Usuários")]
        public User User { get; set; }

        [Column("Status")]
        [Display(Name = "Status")]
        public Status Status { get; set; }
        
        [Column("Types")]
        [Display(Name = "Tipo")]
        [Required(ErrorMessage = "O campo tipo é necessário")]
        public Types Type { get; set; }

        [Column("Equipament")]
        [Display(Name = "Equipamentos")]
        [Required(ErrorMessage = "O campo Equipamento é necessário")]
        public String Equipament { get; set; }

        [Column("Description")]
        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "O campo Descrição é necessário")]
        public String Description { get; set; }

        [DefaultValue(false)]
        [Column("Approval")]
        [Display(Name = "Aprovação")]
        public bool Approval { get; set; }

        public String DescriptionDeclineApproval { get; set; }
    }
}
