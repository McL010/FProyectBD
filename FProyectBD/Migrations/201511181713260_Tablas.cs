namespace FProyectBD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tablas : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Agentes",
                c => new
                    {
                        IdAgente = c.Int(nullable: false, identity: true),
                        NAgente = c.Int(nullable: false),
                        Nombre = c.String(),
                        Apellidos = c.String(),
                        Cargo = c.String(),
                        Sueldo = c.Int(nullable: false),
                        Sanciones_IdS = c.Int(),
                    })
                .PrimaryKey(t => t.IdAgente)
                .ForeignKey("dbo.Sanciones", t => t.Sanciones_IdS)
                .Index(t => t.Sanciones_IdS);
            
            CreateTable(
                "dbo.Ciudadanos",
                c => new
                    {
                        IdC = c.Int(nullable: false, identity: true),
                        IdCV = c.Int(nullable: false),
                        Nombre = c.String(),
                        Direccion = c.String(),
                        Ciudad = c.String(),
                        Telefono = c.String(),
                        Vehiculos_IdV = c.Int(),
                    })
                .PrimaryKey(t => t.IdC)
                .ForeignKey("dbo.Vehiculos", t => t.Vehiculos_IdV)
                .Index(t => t.Vehiculos_IdV);
            
            CreateTable(
                "dbo.Sanciones",
                c => new
                    {
                        IdS = c.Int(nullable: false, identity: true),
                        Fecha = c.String(),
                        Lugar = c.String(),
                        TipoS = c.Int(nullable: false),
                        NAgente = c.Int(nullable: false),
                        Matricula = c.String(),
                    })
                .PrimaryKey(t => t.IdS);
            
            CreateTable(
                "dbo.TipoSancions",
                c => new
                    {
                        IdT = c.Int(nullable: false, identity: true),
                        TipoS = c.Int(nullable: false),
                        Sancion = c.String(),
                        Importe = c.Int(nullable: false),
                        Sanciones_IdS = c.Int(),
                    })
                .PrimaryKey(t => t.IdT)
                .ForeignKey("dbo.Sanciones", t => t.Sanciones_IdS)
                .Index(t => t.Sanciones_IdS);
            
            CreateTable(
                "dbo.Vehiculos",
                c => new
                    {
                        IdV = c.Int(nullable: false, identity: true),
                        Matricula = c.String(),
                        IdC = c.Int(nullable: false),
                        Marca = c.String(),
                        Modelo = c.String(),
                        Tipo = c.String(),
                        Sanciones_IdS = c.Int(),
                    })
                .PrimaryKey(t => t.IdV)
                .ForeignKey("dbo.Sanciones", t => t.Sanciones_IdS)
                .Index(t => t.Sanciones_IdS);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vehiculos", "Sanciones_IdS", "dbo.Sanciones");
            DropForeignKey("dbo.Ciudadanos", "Vehiculos_IdV", "dbo.Vehiculos");
            DropForeignKey("dbo.TipoSancions", "Sanciones_IdS", "dbo.Sanciones");
            DropForeignKey("dbo.Agentes", "Sanciones_IdS", "dbo.Sanciones");
            DropIndex("dbo.Vehiculos", new[] { "Sanciones_IdS" });
            DropIndex("dbo.TipoSancions", new[] { "Sanciones_IdS" });
            DropIndex("dbo.Ciudadanos", new[] { "Vehiculos_IdV" });
            DropIndex("dbo.Agentes", new[] { "Sanciones_IdS" });
            DropTable("dbo.Vehiculos");
            DropTable("dbo.TipoSancions");
            DropTable("dbo.Sanciones");
            DropTable("dbo.Ciudadanos");
            DropTable("dbo.Agentes");
        }
    }
}
