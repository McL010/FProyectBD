using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Finalbd.Cbd
{
    public class Agente
    {
        [Key]
        public int IDAgente { get; set; }
        public string Nombre { get; set; }
        public string Departamento { get; set; }
        public virtual ICollection<Sancion> Sanciones { get; set; }

    }
}
