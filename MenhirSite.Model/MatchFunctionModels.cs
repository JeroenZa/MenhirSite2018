namespace MenhirSite.Model
{
    public class Match : NonDeletableBaseModel
    {
        public string SportLinkId { get; set; }
        public Person Referee { get; set; }
        public Person Umpire { get; set; }
        public Person Scorer { get; set; }
        public Person Timer { get; set; }
        public Person Commisaris { get; set; }
    }
}