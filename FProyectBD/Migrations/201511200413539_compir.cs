namespace FProyectBD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class compir : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Ciudadanos", "IdCV", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Ciudadanos", "IdCV", c => c.Int(nullable: false));
        }
    }
}
