using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FProyectBD.DBClass
{
    public class Agentes
    {
        [Key]
        public int IdAgente { get; set; }
        public virtual int NAgente { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Cargo { get; set; }
        public int Sueldo { get; set; }
 
    }
}
