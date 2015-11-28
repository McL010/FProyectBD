namespace FProyectBD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adsd : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SancionesCiudadanos", "Sanciones_IdS", "dbo.Sanciones");
            DropForeignKey("dbo.SancionesCiudadanos", "Ciudadanos_IdC", "dbo.Ciudadanos");
            DropForeignKey("dbo.Vehiculos", "Sanciones_IdS", "dbo.Sanciones");
            DropIndex("dbo.Vehiculos", new[] { "Sanciones_IdS" });
            DropIndex("dbo.SancionesCiudadanos", new[] { "Sanciones_IdS" });
            DropIndex("dbo.SancionesCiudadanos", new[] { "Ciudadanos_IdC" });
            CreateTable(
                "dbo.VehiculosSanciones",
                c => new
                    {
                        Vehiculos_IdV = c.Int(nullable: false),
                        Sanciones_IdS = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Vehiculos_IdV, t.Sanciones_IdS })
                .ForeignKey("dbo.Vehiculos", t => t.Vehiculos_IdV, cascadeDelete: true)
                .ForeignKey("dbo.Sanciones", t => t.Sanciones_IdS, cascadeDelete: true)
                .Index(t => t.Vehiculos_IdV)
                .Index(t => t.Sanciones_IdS);
            
            AddColumn("dbo.Sanciones", "Ciudadanos_IdC", c => c.Int());
            CreateIndex("dbo.Sanciones", "Ciudadanos_IdC");
            AddForeignKey("dbo.Sanciones", "Ciudadanos_IdC", "dbo.Ciudadanos", "IdC");
            DropColumn("dbo.Vehiculos", "Sanciones_IdS");
            DropTable("dbo.SancionesCiudadanos");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.SancionesCiudadanos",
                c => new
                    {
                        Sanciones_IdS = c.Int(nullable: false),
                        Ciudadanos_IdC = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Sanciones_IdS, t.Ciudadanos_IdC });
            
            AddColumn("dbo.Vehiculos", "Sanciones_IdS", c => c.Int());
            DropForeignKey("dbo.Sanciones", "Ciudadanos_IdC", "dbo.Ciudadanos");
            DropForeignKey("dbo.VehiculosSanciones", "Sanciones_IdS", "dbo.Sanciones");
            DropForeignKey("dbo.VehiculosSanciones", "Vehiculos_IdV", "dbo.Vehiculos");
            DropIndex("dbo.VehiculosSanciones", new[] { "Sanciones_IdS" });
            DropIndex("dbo.VehiculosSanciones", new[] { "Vehiculos_IdV" });
            DropIndex("dbo.Sanciones", new[] { "Ciudadanos_IdC" });
            DropColumn("dbo.Sanciones", "Ciudadanos_IdC");
            DropTable("dbo.VehiculosSanciones");
            CreateIndex("dbo.SancionesCiudadanos", "Ciudadanos_IdC");
            CreateIndex("dbo.SancionesCiudadanos", "Sanciones_IdS");
            CreateIndex("dbo.Vehiculos", "Sanciones_IdS");
            AddForeignKey("dbo.Vehiculos", "Sanciones_IdS", "dbo.Sanciones", "IdS");
            AddForeignKey("dbo.SancionesCiudadanos", "Ciudadanos_IdC", "dbo.Ciudadanos", "IdC", cascadeDelete: true);
            AddForeignKey("dbo.SancionesCiudadanos", "Sanciones_IdS", "dbo.Sanciones", "IdS", cascadeDelete: true);
        }
    }
}
