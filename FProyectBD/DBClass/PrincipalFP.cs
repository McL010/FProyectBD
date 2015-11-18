using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace FProyectBD.DBClass
{
    public class PrincipalFP: DbContext{
        public DbSet<Altas> Altas {get; set;}
        public DbSet<Agentes> Agentes { get; set; }
        public DbSet<Ciudadanos> Ciudadanos { get; set; }
        public DbSet<Sanciones> Sanciones { get; set; }
        public DbSet<TipoSancion> TipoSancion { get; set; }
        public DbSet<Vehiculos> Vehiculos { get; set; }
    }
    
    }

