namespace FinalCSharpChallenge.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "First_Name", c => c.String());
            AddColumn("dbo.Students", "Last_Name", c => c.String());
            DropColumn("dbo.Students", "FirstName");
            DropColumn("dbo.Students", "LastName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "LastName", c => c.String());
            AddColumn("dbo.Students", "FirstName", c => c.String());
            DropColumn("dbo.Students", "Last_Name");
            DropColumn("dbo.Students", "First_Name");
        }
    }
}
