namespace login11.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userpass2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.UserPasswords", "PasswordHash2");
            DropColumn("dbo.UserPasswords", "PasswordHash3");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserPasswords", "PasswordHash3", c => c.String());
            AddColumn("dbo.UserPasswords", "PasswordHash2", c => c.String());
        }
    }
}
