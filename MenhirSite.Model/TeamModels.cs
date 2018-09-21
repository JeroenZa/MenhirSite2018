using System;

namespace MenhirSite.Model
{
    public class Team : NonDeletableBaseModel 
    {
        public string MenuName { get; set; }
        public string Name { get; set; }
        public string NbbId { get; set; }
        public string SportLinkId { get; set; }
        public bool Active { get; set; }
        public DateTime ActiveFrom { get; set; }
        public DateTime? ActiveUntil { get; set; }
        public string TeamPhoto { get; set; }
    }
}