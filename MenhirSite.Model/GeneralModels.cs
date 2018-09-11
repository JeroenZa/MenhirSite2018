using System.Collections.Generic;
using Newtonsoft.Json;

namespace MenhirSite.Model
{
    public class File : DeletableBaseModel
    {
        public string Title { get; set; }
        public FileType Type { get; set; }
        public string Path { get; set; }
        public int SizeInKb { get; set; }

        [JsonIgnore]
        public virtual List<Article> Articles { get; set; }
    }

    public enum FileType
    {
        Pdf,
        Excel,
        Word,
        Text,
        Other
    }
}