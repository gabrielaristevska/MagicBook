namespace Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class final3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Books", "Description", c => c.String());
            AlterColumn("dbo.Books", "DetailsDescription", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Books", "DetailsDescription", c => c.String());
            AlterColumn("dbo.Books", "Description", c => c.String(nullable: false));
        }
    }
}
