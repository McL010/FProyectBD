namespace Finalbd.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Agentes",
                c => new
                    {
                        IDAgente = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Departamento = c.String(),
                    })
                .PrimaryKey(t => t.IDAgente);
            
            CreateTable(
                "dbo.Sancions",
                c => new
                    {
                        IdS = c.Int(nullable: false, identity: true),
                        Precio = c.Int(nullable: false),
                        IDAuto = c.Int(nullable: false),
                        IDCiudadano = c.Int(nullable: false),
                        IDAgente = c.Int(nullable: false),
                        IDMulta = c.Int(nullable: false),
                        Fec = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IdS)
                .ForeignKey("dbo.Agentes", t => t.IDAgente, cascadeDelete: true)
                .ForeignKey("dbo.Autoes", t => t.IDAuto, cascadeDelete: true)
                .ForeignKey("dbo.Multas", t => t.IDMulta, cascadeDelete: true)
                .Index(t => t.IDAuto)
                .Index(t => t.IDAgente)
                .Index(t => t.IDMulta);
            
            CreateTable(
                "dbo.Ciudadanoes",
                c => new
                    {
                        IDCiudadano = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        sexo = c.String(),
                    })
                .PrimaryKey(t => t.IDCiudadano);
            
            CreateTable(
                "dbo.Autoes",
                c => new
                    {
                        IDAuto = c.Int(nullable: false, identity: true),
                        Marca = c.String(),
                        Modelo = c.String(),
                        Placa = c.String(),
                    })
                .PrimaryKey(t => t.IDAuto);
            
            CreateTable(
                "dbo.Multas",
                c => new
                    {
                        IDMulta = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.IDMulta);
            
            CreateTable(
                "dbo.CiudadanoSancions",
                c => new
                    {
                        Ciudadano_IDCiudadano = c.Int(nullable: false),
                        Sancion_IdS = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Ciudadano_IDCiudadano, t.Sancion_IdS })
                .ForeignKey("dbo.Ciudadanoes", t => t.Ciudadano_IDCiudadano, cascadeDelete: true)
                .ForeignKey("dbo.Sancions", t => t.Sancion_IdS, cascadeDelete: true)
                .Index(t => t.Ciudadano_IDCiudadano)
                .Index(t => t.Sancion_IdS);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sancions", "IDMulta", "dbo.Multas");
            DropForeignKey("dbo.Sancions", "IDAuto", "dbo.Autoes");
            DropForeignKey("dbo.Sancions", "IDAgente", "dbo.Agentes");
            DropForeignKey("dbo.CiudadanoSancions", "Sancion_IdS", "dbo.Sancions");
            DropForeignKey("dbo.CiudadanoSancions", "Ciudadano_IDCiudadano", "dbo.Ciudadanoes");
            DropIndex("dbo.CiudadanoSancions", new[] { "Sancion_IdS" });
            DropIndex("dbo.CiudadanoSancions", new[] { "Ciudadano_IDCiudadano" });
            DropIndex("dbo.Sancions", new[] { "IDMulta" });
            DropIndex("dbo.Sancions", new[] { "IDAgente" });
            DropIndex("dbo.Sancions", new[] { "IDAuto" });
            DropTable("dbo.CiudadanoSancions");
            DropTable("dbo.Multas");
            DropTable("dbo.Autoes");
            DropTable("dbo.Ciudadanoes");
            DropTable("dbo.Sancions");
            DropTable("dbo.Agentes");
        }
    }
}
