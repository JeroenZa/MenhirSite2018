namespace MenhirSite.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TeamModelAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MenuName = c.String(),
                        Name = c.String(),
                        NbbId = c.String(),
                        SportLinkId = c.String(),
                        Active = c.Boolean(nullable: false),
                        ActiveFrom = c.DateTime(nullable: false),
                        ActiveUntil = c.DateTime(),
                        TeamPhoto = c.String(),
                        DeletedOn = c.DateTime(),
                        CreatedBy = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Teams");
        }
    }
}
