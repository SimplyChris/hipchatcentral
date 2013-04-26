namespace HipChatCentral.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRegistrationId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GroupAccounts", "RegistrationId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.GroupAccounts", "RegistrationId");
        }
    }
}
