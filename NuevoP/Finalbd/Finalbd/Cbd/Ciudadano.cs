using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Finalbd.Cbd
{
    
   public class Ciudadano
    {

       //public class Ciudadano(){
       
       //this.Ciudadano = new ICollection<Ciudadano>();
       
       //}

        [Key] public int IDCiudadano { get; set; }
        public  string Nombre { get; set; }
        public string sexo { get; set; }
        public virtual ICollection<Sancion> Sanciones { get; set; }





    }
}
