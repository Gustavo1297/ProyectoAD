using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackPrueba.Entities
{
    public class usuario
    {
        [Key]
        public int Id_usuario { get; set; }
        public string usuarios { get; set; }

        public string pwd { get; set; }

        public string name_usuarios { get; set; }

        public string correo { get; set; }

        public int id_rol { get; set; }

    }
}
