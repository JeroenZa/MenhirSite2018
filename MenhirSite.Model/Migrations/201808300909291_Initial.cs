namespace MenhirSite.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Articles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Text = c.String(),
                        Author = c.String(),
                        PublishFrom = c.DateTime(nullable: false),
                        PublishUntil = c.DateTime(nullable: false),
                        Order = c.Int(nullable: false),
                        ArticleState = c.Int(nullable: false),
                        DeletedOn = c.DateTime(),
                        CreatedBy = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Files",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Type = c.Int(nullable: false),
                        Path = c.String(),
                        SizeInKb = c.Int(nullable: false),
                        CreatedBy = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Matches",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SportLinkId = c.String(),
                        DeletedOn = c.DateTime(),
                        CreatedBy = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                        ModifiedOn = c.DateTime(nullable: false),
                        Commisaris_Id = c.Int(),
                        Referee_Id = c.Int(),
                        Scorer_Id = c.Int(),
                        Timer_Id = c.Int(),
                        Umpire_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.Commisaris_Id)
                .ForeignKey("dbo.People", t => t.Referee_Id)
                .ForeignKey("dbo.People", t => t.Scorer_Id)
                .ForeignKey("dbo.People", t => t.Timer_Id)
                .ForeignKey("dbo.People", t => t.Umpire_Id)
                .Index(t => t.Commisaris_Id)
                .Index(t => t.Referee_Id)
                .Index(t => t.Scorer_Id)
                .Index(t => t.Timer_Id)
                .Index(t => t.Umpire_Id);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        RefereeLicence = c.String(),
                        DeletedOn = c.DateTime(),
                        CreatedBy = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Sponsors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Website = c.String(),
                        ImagePath = c.String(),
                        ImageAltText = c.String(),
                        CreatedBy = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FileArticles",
                c => new
                    {
                        File_Id = c.Int(nullable: false),
                        Article_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.File_Id, t.Article_Id })
                .ForeignKey("dbo.Files", t => t.File_Id, cascadeDelete: true)
                .ForeignKey("dbo.Articles", t => t.Article_Id, cascadeDelete: true)
                .Index(t => t.File_Id)
                .Index(t => t.Article_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Matches", "Umpire_Id", "dbo.People");
            DropForeignKey("dbo.Matches", "Timer_Id", "dbo.People");
            DropForeignKey("dbo.Matches", "Scorer_Id", "dbo.People");
            DropForeignKey("dbo.Matches", "Referee_Id", "dbo.People");
            DropForeignKey("dbo.Matches", "Commisaris_Id", "dbo.People");
            DropForeignKey("dbo.FileArticles", "Article_Id", "dbo.Articles");
            DropForeignKey("dbo.FileArticles", "File_Id", "dbo.Files");
            DropIndex("dbo.FileArticles", new[] { "Article_Id" });
            DropIndex("dbo.FileArticles", new[] { "File_Id" });
            DropIndex("dbo.Matches", new[] { "Umpire_Id" });
            DropIndex("dbo.Matches", new[] { "Timer_Id" });
            DropIndex("dbo.Matches", new[] { "Scorer_Id" });
            DropIndex("dbo.Matches", new[] { "Referee_Id" });
            DropIndex("dbo.Matches", new[] { "Commisaris_Id" });
            DropTable("dbo.FileArticles");
            DropTable("dbo.Sponsors");
            DropTable("dbo.People");
            DropTable("dbo.Matches");
            DropTable("dbo.Files");
            DropTable("dbo.Articles");
        }
    }
}
