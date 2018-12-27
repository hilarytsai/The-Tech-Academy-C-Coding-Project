namespace CodeFirstFinal4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Planets",
                c => new
                    {
                        PlanetID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.PlanetID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Planets");
        }
    }
}
