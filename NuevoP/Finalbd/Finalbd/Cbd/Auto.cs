using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Finalbd.Cbd
{
   public class Auto
    {

        [Key] 
        public int IDAuto { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Placa { get; set; }
        public virtual ICollection<Sancion> Sanciones { get; set; }
    }
}
