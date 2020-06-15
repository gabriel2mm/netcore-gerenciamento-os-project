using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GDR.Models
{
    public class Order
    {
        [Key]
        public Guid Id { get; set; }

        [Column("Users")]
        [Display(Name = "Usuários")]
        public User User { get; set; }

        [Column("Description")]
        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "O campo Descrição é necessário")]
        public String Description { get; set; }
        
        [Column("Queue")]
        [Display(Name = "Fila")]
        public GDR.Enumerators.Queue Queue { get; set; }

        [Column("Request")]
        [Display(Name = "Requisição")]
        [Required(ErrorMessage = "O campo requisição é obrigatório")]
        public Request Request { get; set; }

        public String Attachment { get; set; }

    }
}
