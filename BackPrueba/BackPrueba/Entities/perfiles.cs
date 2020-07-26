using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackPrueba.Entities
{
    public class perfiles
    {
        [Key]
        public int id_perfil { get; set; }
        public string perfil { get; set; }
    }
}
