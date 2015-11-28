namespace FProyectBD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class kesç : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SancionesCiudadanos",
                c => new
                    {
                        Sanciones_IdS = c.Int(nullable: false),
                        Ciudadanos_IdC = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Sanciones_IdS, t.Ciudadanos_IdC })
                .ForeignKey("dbo.Sanciones", t => t.Sanciones_IdS, cascadeDelete: true)
                .ForeignKey("dbo.Ciudadanos", t => t.Ciudadanos_IdC, cascadeDelete: true)
                .Index(t => t.Sanciones_IdS)
                .Index(t => t.Ciudadanos_IdC);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SancionesCiudadanos", "Ciudadanos_IdC", "dbo.Ciudadanos");
            DropForeignKey("dbo.SancionesCiudadanos", "Sanciones_IdS", "dbo.Sanciones");
            DropIndex("dbo.SancionesCiudadanos", new[] { "Ciudadanos_IdC" });
            DropIndex("dbo.SancionesCiudadanos", new[] { "Sanciones_IdS" });
            DropTable("dbo.SancionesCiudadanos");
        }
    }
}
