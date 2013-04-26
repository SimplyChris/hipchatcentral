namespace HipChatCentral.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddKey1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.HipChatApiKeys", "GroupId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.HipChatApiKeys", "GroupId", c => c.Int(nullable: false));
        }
    }
}
