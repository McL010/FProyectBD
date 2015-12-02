using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finalbd.Cbd
{
 public   class Mibd:DbContext
    {
        public DbSet<Agente> Agens { get; set; }
        public DbSet<Auto> Auts { get; set; }
        public DbSet<Ciudadano> Cius { get; set; }
        public DbSet<Multa> Mults { get; set; }
        public DbSet<Sancion> Sans { get; set; }
        







    }
}
