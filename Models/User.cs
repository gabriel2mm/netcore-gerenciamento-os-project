
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GDR.Models
{
    [Table("Users")]
    public class User : IdentityUser
    {
        [Column("First_name")]
        [StringLength(50, ErrorMessage = "First_name só pode conter 50 caractres")]
        public string First_Name { get; set; }

        [Column("Last_name")]
        [StringLength(50, ErrorMessage = "Last_name só pode conter 50 caractres")]
        public string Last_name { get; set; }

        [Column("Login")]
        [StringLength(30, ErrorMessage = "Login só pode conter 30 caractres")]
        public string Login { get; set; }

        [Column("Perfil")]
        [Required(ErrorMessage = "Perfil é necessário")]
        private String Role { get; set; }
    }
}
