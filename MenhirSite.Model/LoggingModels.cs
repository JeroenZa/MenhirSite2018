namespace MenhirSite.Model
{
    public class Logging : DeletableBaseModel
    {
        public int EventId { get; set; }
        public string IncidentId { get; set; }
        public string Message { get; set; }
        public string Exception { get; set; }
        public string Stack { get; set; }
        public LogLevel Level { get; set; }
    }

    public enum LogLevel
    {
        Debug = 1,
        Information = 2,
        Warning = 3,
        Error = 4,
        Fatal = 5
    }

}