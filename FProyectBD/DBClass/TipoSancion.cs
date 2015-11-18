using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FProyectBD.DBClass
{
    public class TipoSancion
    {
        [Key]
        public int IdT { get; set; }
        public virtual int TipoS { get; set; }
        public string Sancion { get; set; }
        public int Importe { get; set; }
        
        
    }
}
