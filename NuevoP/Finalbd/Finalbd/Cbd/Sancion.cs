using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Finalbd.Cbd
{
    public class Sancion
    {
        [Key]
        public int IdS { get; set; }
        public virtual int Precio { get; set; }
        public virtual int IDAuto { get; set; }
        public virtual int IDCiudadano { get; set; }
        public virtual int IDAgente { get; set; }
        public virtual int IDMulta { get; set; }
        public DateTime Fec { get; set; }


        public virtual ICollection<Ciudadano> Ciudadanos{ get; set; }
    }
}
