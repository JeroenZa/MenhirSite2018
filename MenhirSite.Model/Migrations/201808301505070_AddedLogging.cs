namespace MenhirSite.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedLogging : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Loggings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EventId = c.Int(nullable: false),
                        IncidentId = c.String(),
                        Message = c.String(),
                        Exception = c.String(),
                        Stack = c.String(),
                        Level = c.Int(nullable: false),
                        CreatedBy = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Loggings");
        }
    }
}
