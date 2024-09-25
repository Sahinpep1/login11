namespace login11.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VerificationExpiry : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "VerificationTokenExpiry", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "VerificationTokenExpiry");
        }
    }
}
