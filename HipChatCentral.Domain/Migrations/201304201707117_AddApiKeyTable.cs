namespace HipChatCentral.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddApiKeyTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HipChatApiKeys",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GroupId = c.Int(nullable: false),
                        Name = c.String(),
                        ApiKey = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.HipChatApiKeys");
        }
    }
}
