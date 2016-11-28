namespace RnD.Net.EntityFramework.CD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class version_1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Drones", "Weapon", _ => _.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Drones", "Weapon");
        }
    }
}
