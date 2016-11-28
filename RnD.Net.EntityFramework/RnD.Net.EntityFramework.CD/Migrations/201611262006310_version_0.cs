namespace RnD.Net.EntityFramework.CD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class version_0 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DroneConfigurations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Config = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Drones",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Configuration_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DroneConfigurations", t => t.Configuration_Id)
                .Index(t => t.Configuration_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Drones", "Configuration_Id", "dbo.DroneConfigurations");
            DropIndex("dbo.Drones", new[] { "Configuration_Id" });
            DropTable("dbo.Drones");
            DropTable("dbo.DroneConfigurations");
        }
    }
}
