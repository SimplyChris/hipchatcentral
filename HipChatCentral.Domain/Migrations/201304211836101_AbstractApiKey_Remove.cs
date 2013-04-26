namespace HipChatCentral.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AbstractApiKey_Remove : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.HipChatApiKeys", "IsMarkedForDeletion");
            DropColumn("dbo.HipChatApiKeys", "Discriminator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.HipChatApiKeys", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.HipChatApiKeys", "IsMarkedForDeletion", c => c.Boolean());
        }
    }
}
