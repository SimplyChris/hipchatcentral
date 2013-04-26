namespace HipChatCentral.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AbstractApiKey : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HipChatApiKeys", "IsMarkedForDeletion", c => c.Boolean());
            AddColumn("dbo.HipChatApiKeys", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
        
        public override void Down()
        {
            DropColumn("dbo.HipChatApiKeys", "Discriminator");
            DropColumn("dbo.HipChatApiKeys", "IsMarkedForDeletion");
        }
    }
}
