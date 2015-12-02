using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FProyectBD.DBClass
{
   public class reporte
    {
       public reporte()
       {
           this.Ciudadanos = new List<Ciudadanos>();
       }
       [Key]
       public virtual int Idr { get; set; }
       public DateTime Fechar { get; set; }
       public string report { get; set; }

       public virtual List<Ciudadanos> Ciudadanos { get; set; }






    }
}
