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
        [Required(ErrorMessage = "O campo usuário é necessário")]
        public User User { get; set; }

        [Column("Description")]
        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "O campo Descrição é necessário")]
        public String Description { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime Created { get; set; }

        [Column("Request")]
        [Display(Name = "Requisição")]
        [Required(ErrorMessage = "O campo requisição é obrigatório")]
        public Request Request { get; set; }

        public String Attachment { get; set; }

    }
}
