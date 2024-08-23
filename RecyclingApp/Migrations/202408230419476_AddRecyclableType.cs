namespace RecyclingApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRecyclableType : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.RecyclableItems", "ComputedRate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RecyclableItems", "ComputedRate", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
