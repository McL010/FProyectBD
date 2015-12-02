namespace FProyectBD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addimportesanciones : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sanciones", "importeS", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Sanciones", "importeS");
        }
    }
}
