namespace EFMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AutoGeneratedMigration140201044610 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Items", "Data2");
            DropColumn("dbo.Items", "Data3");
            DropColumn("dbo.Items", "Data5");
            DropColumn("dbo.Items", "TestBool");
            DropColumn("dbo.Items", "Something");
            DropColumn("dbo.Items", "ThirdBool3");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Items", "ThirdBool3", c => c.Boolean(nullable: false));
            AddColumn("dbo.Items", "Something", c => c.String());
            AddColumn("dbo.Items", "TestBool", c => c.Boolean(nullable: false));
            AddColumn("dbo.Items", "Data5", c => c.Int(nullable: false));
            AddColumn("dbo.Items", "Data3", c => c.String());
            AddColumn("dbo.Items", "Data2", c => c.String());
        }
    }
}