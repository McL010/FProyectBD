using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FProyectBD.DBClass
{
    public class Sanciones
    {
        [Key]
        public int IdS { get; set; }
        public string Fecha { get; set; }
        public string Lugar { get; set; }
        public int TipoS { get; set; }
        public int NAgente { get; set; }
        public string Matricula { get; set; }
        public int importeS { get; set; }
        public virtual ICollection<Vehiculos> Vehiculos { get; set; }
        public virtual ICollection<TipoSancion> TipoSanciones { get; set; }
        public virtual ICollection<Agentes> Agentes { get; set; }
        
        
    }
}
