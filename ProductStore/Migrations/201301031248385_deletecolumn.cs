namespace ProductStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletecolumn : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Products", "Path");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Path", c => c.String());
        }
    }
}
