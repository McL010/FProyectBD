using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Finalbd.Cbd
{
   public class Multa
    {
        [Key]
        public int IDMulta { get; set; }
        public string Descripcion { get; set; }
  
        public virtual ICollection<Sancion> Sanciones { get; set; }
    }
}
