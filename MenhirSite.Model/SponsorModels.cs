namespace MenhirSite.Model
{
    public class Sponsor : DeletableBaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Website { get; set; }
        public string ImagePath { get; set; }
        public string ImageAltText { get; set; }
    }
}