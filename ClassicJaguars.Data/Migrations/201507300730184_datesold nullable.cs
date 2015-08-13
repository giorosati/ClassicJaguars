namespace ClassicJaguars.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class datesoldnullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Transactions", "DateSold", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Transactions", "DateSold", c => c.DateTime(nullable: false));
        }
    }
}
