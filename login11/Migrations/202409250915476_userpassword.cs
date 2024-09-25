namespace login11.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userpassword : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserPasswords", "PasswordHash2", c => c.String());
            AddColumn("dbo.UserPasswords", "PasswordHash3", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserPasswords", "PasswordHash3");
            DropColumn("dbo.UserPasswords", "PasswordHash2");
        }
    }
}
