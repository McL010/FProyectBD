namespace FProyectBD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class acambiarimport : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Sanciones", "importeS", c => c.Int(nullable: true));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Sanciones", "importeS", c => c.String());
        }
    }
}
