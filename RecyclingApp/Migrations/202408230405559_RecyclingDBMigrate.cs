namespace RecyclingApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RecyclingDBMigrate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.RecyclableItems", "ItemDescription", c => c.String(maxLength: 150));
            AlterColumn("dbo.RecyclableTypes", "Type", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.RecyclableTypes", "Type", c => c.String());
            AlterColumn("dbo.RecyclableItems", "ItemDescription", c => c.String());
        }
    }
}
