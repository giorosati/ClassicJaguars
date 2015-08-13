namespace ClassicJaguars.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class enumgone : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Transactions", "TransType", c => c.String());
            AlterColumn("dbo.Transactions", "NumsMatch", c => c.Boolean());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Transactions", "NumsMatch", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Transactions", "TransType", c => c.Int(nullable: false));
        }
    }
}
