namespace HipChatCentral.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddApiKeyToGroups : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HipChatApiKeys", "GroupAccount_Id", c => c.Int());
            AddForeignKey("dbo.HipChatApiKeys", "GroupAccount_Id", "dbo.GroupAccounts", "Id");
            CreateIndex("dbo.HipChatApiKeys", "GroupAccount_Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.HipChatApiKeys", new[] { "GroupAccount_Id" });
            DropForeignKey("dbo.HipChatApiKeys", "GroupAccount_Id", "dbo.GroupAccounts");
            DropColumn("dbo.HipChatApiKeys", "GroupAccount_Id");
        }
    }
}
