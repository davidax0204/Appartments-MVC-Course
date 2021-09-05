namespace Appartments_MVC_Course.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dataanotaionstoapartment : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Apartments", "OwnerId", c => c.String(nullable: false));
            AlterColumn("dbo.Apartments", "City", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Apartments", "Street", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Apartments", "Street", c => c.String());
            AlterColumn("dbo.Apartments", "City", c => c.String());
            AlterColumn("dbo.Apartments", "OwnerId", c => c.String());
        }
    }
}
