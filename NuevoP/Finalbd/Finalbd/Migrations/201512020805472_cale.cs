namespace Finalbd.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cale : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Sancions", "IDAgente", "dbo.Agentes");
            DropForeignKey("dbo.Sancions", "IDAuto", "dbo.Autoes");
            DropForeignKey("dbo.Sancions", "IDMulta", "dbo.Multas");
            DropIndex("dbo.Sancions", new[] { "IDAuto" });
            DropIndex("dbo.Sancions", new[] { "IDAgente" });
            DropIndex("dbo.Sancions", new[] { "IDMulta" });
            AddColumn("dbo.Sancions", "Agente_IDAgente", c => c.Int());
            AddColumn("dbo.Sancions", "Auto_IDAuto", c => c.Int());
            AddColumn("dbo.Sancions", "Multa_IDMulta", c => c.Int());
            AlterColumn("dbo.Sancions", "IDAuto", c => c.Single(nullable: false));
            AlterColumn("dbo.Sancions", "IDCiudadano", c => c.Single(nullable: false));
            AlterColumn("dbo.Sancions", "IDAgente", c => c.Single(nullable: false));
            AlterColumn("dbo.Sancions", "IDMulta", c => c.Single(nullable: false));
            CreateIndex("dbo.Sancions", "Agente_IDAgente");
            CreateIndex("dbo.Sancions", "Auto_IDAuto");
            CreateIndex("dbo.Sancions", "Multa_IDMulta");
            AddForeignKey("dbo.Sancions", "Agente_IDAgente", "dbo.Agentes", "IDAgente");
            AddForeignKey("dbo.Sancions", "Auto_IDAuto", "dbo.Autoes", "IDAuto");
            AddForeignKey("dbo.Sancions", "Multa_IDMulta", "dbo.Multas", "IDMulta");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sancions", "Multa_IDMulta", "dbo.Multas");
            DropForeignKey("dbo.Sancions", "Auto_IDAuto", "dbo.Autoes");
            DropForeignKey("dbo.Sancions", "Agente_IDAgente", "dbo.Agentes");
            DropIndex("dbo.Sancions", new[] { "Multa_IDMulta" });
            DropIndex("dbo.Sancions", new[] { "Auto_IDAuto" });
            DropIndex("dbo.Sancions", new[] { "Agente_IDAgente" });
            AlterColumn("dbo.Sancions", "IDMulta", c => c.Int(nullable: false));
            AlterColumn("dbo.Sancions", "IDAgente", c => c.Int(nullable: false));
            AlterColumn("dbo.Sancions", "IDCiudadano", c => c.Int(nullable: false));
            AlterColumn("dbo.Sancions", "IDAuto", c => c.Int(nullable: false));
            DropColumn("dbo.Sancions", "Multa_IDMulta");
            DropColumn("dbo.Sancions", "Auto_IDAuto");
            DropColumn("dbo.Sancions", "Agente_IDAgente");
            CreateIndex("dbo.Sancions", "IDMulta");
            CreateIndex("dbo.Sancions", "IDAgente");
            CreateIndex("dbo.Sancions", "IDAuto");
            AddForeignKey("dbo.Sancions", "IDMulta", "dbo.Multas", "IDMulta", cascadeDelete: true);
            AddForeignKey("dbo.Sancions", "IDAuto", "dbo.Autoes", "IDAuto", cascadeDelete: true);
            AddForeignKey("dbo.Sancions", "IDAgente", "dbo.Agentes", "IDAgente", cascadeDelete: true);
        }
    }
}
