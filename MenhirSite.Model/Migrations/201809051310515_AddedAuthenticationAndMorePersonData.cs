namespace MenhirSite.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedAuthenticationAndMorePersonData : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        DeletedOn = c.DateTime(),
                        CreatedBy = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RoleUsers",
                c => new
                    {
                        Role_Id = c.Int(nullable: false),
                        User_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Role_Id, t.User_Id })
                .ForeignKey("dbo.Roles", t => t.Role_Id, cascadeDelete: true)
                .ForeignKey("dbo.People", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.Role_Id)
                .Index(t => t.User_Id);
            
            AddColumn("dbo.People", "FirstName", c => c.String());
            AddColumn("dbo.People", "LastName", c => c.String());
            AddColumn("dbo.People", "UserName", c => c.String());
            AddColumn("dbo.People", "HashedPassword", c => c.String());
            AddColumn("dbo.People", "FailedLoginCount", c => c.Int());
            AddColumn("dbo.People", "LastSuccesfullLogin", c => c.DateTime());
            AddColumn("dbo.People", "LastFailedAttempt", c => c.DateTime());
            AddColumn("dbo.People", "IsLockedOut", c => c.Boolean());
            AddColumn("dbo.People", "AuthenticationToken", c => c.Guid());
            AddColumn("dbo.People", "AuthenticatedUntil", c => c.DateTime());
            AddColumn("dbo.People", "PubIdent", c => c.Guid());
            AddColumn("dbo.People", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.People", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.People", "Name", c => c.String());
            DropForeignKey("dbo.RoleUsers", "User_Id", "dbo.People");
            DropForeignKey("dbo.RoleUsers", "Role_Id", "dbo.Roles");
            DropIndex("dbo.RoleUsers", new[] { "User_Id" });
            DropIndex("dbo.RoleUsers", new[] { "Role_Id" });
            DropColumn("dbo.People", "Discriminator");
            DropColumn("dbo.People", "PubIdent");
            DropColumn("dbo.People", "AuthenticatedUntil");
            DropColumn("dbo.People", "AuthenticationToken");
            DropColumn("dbo.People", "IsLockedOut");
            DropColumn("dbo.People", "LastFailedAttempt");
            DropColumn("dbo.People", "LastSuccesfullLogin");
            DropColumn("dbo.People", "FailedLoginCount");
            DropColumn("dbo.People", "HashedPassword");
            DropColumn("dbo.People", "UserName");
            DropColumn("dbo.People", "LastName");
            DropColumn("dbo.People", "FirstName");
            DropTable("dbo.RoleUsers");
            DropTable("dbo.Roles");
        }
    }
}
