using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FProyectBD.DBClass
{
    public class Vehiculos
    {
        [Key]
        public int IdV { get; set; }
        public virtual string Matricula { get; set; }
        public int IdC { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Tipo { get; set; }
        public virtual ICollection<Ciudadanos> Ciudadanos { get; set; }

    }
}
