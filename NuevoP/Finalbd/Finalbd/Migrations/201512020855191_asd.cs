namespace Finalbd.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class asd : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Sancions", "Agente_IDAgente", "dbo.Agentes");
            DropForeignKey("dbo.Sancions", "Auto_IDAuto", "dbo.Autoes");
            DropForeignKey("dbo.Sancions", "Multa_IDMulta", "dbo.Multas");
            DropIndex("dbo.Sancions", new[] { "Agente_IDAgente" });
            DropIndex("dbo.Sancions", new[] { "Auto_IDAuto" });
            DropIndex("dbo.Sancions", new[] { "Multa_IDMulta" });
            DropColumn("dbo.Sancions", "IDAgente");
            DropColumn("dbo.Sancions", "IDAuto");
            DropColumn("dbo.Sancions", "IDMulta");
            RenameColumn(table: "dbo.Sancions", name: "Agente_IDAgente", newName: "IDAgente");
            RenameColumn(table: "dbo.Sancions", name: "Auto_IDAuto", newName: "IDAuto");
            RenameColumn(table: "dbo.Sancions", name: "Multa_IDMulta", newName: "IDMulta");
            AlterColumn("dbo.Sancions", "IDAuto", c => c.Int(nullable: false));
            AlterColumn("dbo.Sancions", "IDCiudadano", c => c.Int(nullable: false));
            AlterColumn("dbo.Sancions", "IDAgente", c => c.Int(nullable: false));
            AlterColumn("dbo.Sancions", "IDMulta", c => c.Int(nullable: false));
            AlterColumn("dbo.Sancions", "IDAgente", c => c.Int(nullable: false));
            AlterColumn("dbo.Sancions", "IDAuto", c => c.Int(nullable: false));
            AlterColumn("dbo.Sancions", "IDMulta", c => c.Int(nullable: false));
            CreateIndex("dbo.Sancions", "IDAuto");
            CreateIndex("dbo.Sancions", "IDAgente");
            CreateIndex("dbo.Sancions", "IDMulta");
            AddForeignKey("dbo.Sancions", "IDAgente", "dbo.Agentes", "IDAgente", cascadeDelete: true);
            AddForeignKey("dbo.Sancions", "IDAuto", "dbo.Autoes", "IDAuto", cascadeDelete: true);
            AddForeignKey("dbo.Sancions", "IDMulta", "dbo.Multas", "IDMulta", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sancions", "IDMulta", "dbo.Multas");
            DropForeignKey("dbo.Sancions", "IDAuto", "dbo.Autoes");
            DropForeignKey("dbo.Sancions", "IDAgente", "dbo.Agentes");
            DropIndex("dbo.Sancions", new[] { "IDMulta" });
            DropIndex("dbo.Sancions", new[] { "IDAgente" });
            DropIndex("dbo.Sancions", new[] { "IDAuto" });
            AlterColumn("dbo.Sancions", "IDMulta", c => c.Int());
            AlterColumn("dbo.Sancions", "IDAuto", c => c.Int());
            AlterColumn("dbo.Sancions", "IDAgente", c => c.Int());
            AlterColumn("dbo.Sancions", "IDMulta", c => c.String());
            AlterColumn("dbo.Sancions", "IDAgente", c => c.String());
            AlterColumn("dbo.Sancions", "IDCiudadano", c => c.String());
            AlterColumn("dbo.Sancions", "IDAuto", c => c.String());
            RenameColumn(table: "dbo.Sancions", name: "IDMulta", newName: "Multa_IDMulta");
            RenameColumn(table: "dbo.Sancions", name: "IDAuto", newName: "Auto_IDAuto");
            RenameColumn(table: "dbo.Sancions", name: "IDAgente", newName: "Agente_IDAgente");
            AddColumn("dbo.Sancions", "IDMulta", c => c.String());
            AddColumn("dbo.Sancions", "IDAuto", c => c.String());
            AddColumn("dbo.Sancions", "IDAgente", c => c.String());
            CreateIndex("dbo.Sancions", "Multa_IDMulta");
            CreateIndex("dbo.Sancions", "Auto_IDAuto");
            CreateIndex("dbo.Sancions", "Agente_IDAgente");
            AddForeignKey("dbo.Sancions", "Multa_IDMulta", "dbo.Multas", "IDMulta");
            AddForeignKey("dbo.Sancions", "Auto_IDAuto", "dbo.Autoes", "IDAuto");
            AddForeignKey("dbo.Sancions", "Agente_IDAgente", "dbo.Agentes", "IDAgente");
        }
    }
}
