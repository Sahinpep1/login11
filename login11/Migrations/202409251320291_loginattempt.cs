namespace login11.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class loginattempt : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LoginAttempts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false),
                        AttemptedAt = c.DateTime(nullable: false),
                        IsSuccessful = c.Boolean(nullable: false),
                        FailureReason = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.LoginAttempts");
        }
    }
}
