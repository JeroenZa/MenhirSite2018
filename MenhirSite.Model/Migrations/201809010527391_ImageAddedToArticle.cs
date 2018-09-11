namespace MenhirSite.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ImageAddedToArticle : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Articles", "ImagePath", c => c.String());
            AddColumn("dbo.Articles", "ImagePosition", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Articles", "ImagePosition");
            DropColumn("dbo.Articles", "ImagePath");
        }
    }
}
