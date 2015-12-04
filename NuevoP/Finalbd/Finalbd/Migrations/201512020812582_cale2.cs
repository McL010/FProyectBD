namespace Finalbd.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cale2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Sancions", "IDAuto", c => c.String());
            AlterColumn("dbo.Sancions", "IDCiudadano", c => c.String());
            AlterColumn("dbo.Sancions", "IDAgente", c => c.String());
            AlterColumn("dbo.Sancions", "IDMulta", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Sancions", "IDMulta", c => c.Single(nullable: false));
            AlterColumn("dbo.Sancions", "IDAgente", c => c.Single(nullable: false));
            AlterColumn("dbo.Sancions", "IDCiudadano", c => c.Single(nullable: false));
            AlterColumn("dbo.Sancions", "IDAuto", c => c.Single(nullable: false));
        }
    }
}
