using System;
using System.Collections.Generic;

namespace MenhirSite.Model
{
    public class Article : NonDeletableBaseModel
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public string Author { get; set; }
        public string ImagePath { get; set; }
        public ImagePosition ImagePosition { get; set; }
        public DateTime PublishFrom { get; set; } = DateTime.MinValue;
        public DateTime PublishUntil { get; set; } = DateTime.MaxValue;
        public int Order { get; set; }
        public ArticleState ArticleState { get; set; } = ArticleState.Draft;
        public virtual List<File> Files { get; set; }
    }

    public enum ArticleState
    {
        Draft,
        Published,
        Archived
    }

    [Flags]
    public enum ImagePosition
    {
        Top,
        Left,
        Right,
        Bottom
    }
}