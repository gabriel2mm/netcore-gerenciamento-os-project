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
        [Display(Name="Número da Requisição")]
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
        [Column("DPTOPayment")]
        public bool isDptoPayment { get; set; }

        [DefaultValue(false)]
        [Column("Approval")]
        [Display(Name = "Aprovação")]
        public bool Approval { get; set; }

        [Display(Name = "Descrição de não aprovação")]
        public String DescriptionDeclineApproval { get; set; }

        [Column("DescriptionSupport")]
        [Display(Name = "Descrição do Suporte")]
        public String DescriptionsSupport { get; set; }

        [Column("TechnicianDescription")]
        [Display(Name = "Descrição do Técnico")]
        public String TechnicianDescription { get; set; }

        [Column("Scheduling")]
        [Display(Name = "Data de agendamento")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTime Scheduling { get; set; }


        public Request Clone(){
            Request request = this.MemberwiseClone() as Request;
            request.Id = this.Id;
            request.Equipament = this.Equipament;
            request.isDptoPayment = this.isDptoPayment;
            request.Scheduling = this.Scheduling;
            request.Status = this.Status;
            request.TechnicianDescription = this.TechnicianDescription;
            request.Type = this.Type;
            request.User = this.User.Clone();
            request.Approval = this.Approval;
            request.Description = this.Description;
            request.DescriptionDeclineApproval = this.DescriptionDeclineApproval;
            request.DescriptionsSupport =this.DescriptionsSupport;

            return request;
        }        
    }
}
