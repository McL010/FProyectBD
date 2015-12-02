namespace FProyectBD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dada : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Sanciones", "Ciudadanos_IdC", "dbo.Ciudadanos");
            DropIndex("dbo.Sanciones", new[] { "Ciudadanos_IdC" });
            CreateTable(
                "dbo.reportes",
                c => new
                    {
                        Idr = c.Int(nullable: false, identity: true),
                        Fechar = c.DateTime(nullable: false),
                        report = c.String(),
                    })
                .PrimaryKey(t => t.Idr);
            
            CreateTable(
                "dbo.reporteCiudadanos",
                c => new
                    {
                        reporte_Idr = c.Int(nullable: false),
                        Ciudadanos_IdC = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.reporte_Idr, t.Ciudadanos_IdC })
                .ForeignKey("dbo.reportes", t => t.reporte_Idr, cascadeDelete: true)
                .ForeignKey("dbo.Ciudadanos", t => t.Ciudadanos_IdC, cascadeDelete: true)
                .Index(t => t.reporte_Idr)
                .Index(t => t.Ciudadanos_IdC);
            
            DropColumn("dbo.Sanciones", "Ciudadanos_IdC");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Sanciones", "Ciudadanos_IdC", c => c.Int());
            DropForeignKey("dbo.reporteCiudadanos", "Ciudadanos_IdC", "dbo.Ciudadanos");
            DropForeignKey("dbo.reporteCiudadanos", "reporte_Idr", "dbo.reportes");
            DropIndex("dbo.reporteCiudadanos", new[] { "Ciudadanos_IdC" });
            DropIndex("dbo.reporteCiudadanos", new[] { "reporte_Idr" });
            DropTable("dbo.reporteCiudadanos");
            DropTable("dbo.reportes");
            CreateIndex("dbo.Sanciones", "Ciudadanos_IdC");
            AddForeignKey("dbo.Sanciones", "Ciudadanos_IdC", "dbo.Ciudadanos", "IdC");
        }
    }
}
