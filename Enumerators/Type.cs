using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GDR.Enumerators
{
    public enum Types
    {
        [Display(Name= "Substituição de Equipamento")]
        Equipamento = 0,
        [Display(Name = "Substituição de peças por defeito")]
        Peça = 1,
        [Display(Name = "Suporte técnico")]
        Suporte = 2,
        [Display(Name = "Atualização de software")]
        Software =3,
        [Display(Name = "Atualização de hardware")]
        Hardware = 4

    }
}
