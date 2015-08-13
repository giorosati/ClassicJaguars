namespace ClassicJaguars.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class useridontransaction : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Transactions", "UserId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Transactions", "UserId");
        }
    }
}
