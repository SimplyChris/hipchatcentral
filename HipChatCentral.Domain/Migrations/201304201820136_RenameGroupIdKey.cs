namespace HipChatCentral.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameGroupIdKey : DbMigration
    {
        public override void Up()
        {                        
            DropColumn("dbo.HipChatApiKeys", "GroupId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.HipChatApiKeys", "GroupId", c => c.Int(nullable: false));
            AlterColumn("dbo.HipChatApiKeys", "GroupAccount_Id", c => c.Int());
            RenameColumn(table: "dbo.HipChatApiKeys", name: "GroupAccount_Id1", newName: "GroupAccount_Id");
        }
    }
}
