using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace MenhirSite.Model
{
    public class Person : NonDeletableBaseModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string RefereeLicence { get; set; }
    }

    public class User : Person
    {
        public User()
        {
            Roles = new List<Role>();
        }

        public string UserName { get; set; }
        public string HashedPassword { get; set; }
        public List<Role> Roles { get; set; }
        public int FailedLoginCount { get; set; }
        public DateTime? LastSuccesfullLogin { get; set; }
        public DateTime? LastFailedAttempt { get; set; }
        public bool IsLockedOut { get; set; }
        public Guid? AuthenticationToken { get; set; }
        public DateTime? AuthenticatedUntil { get; set; }
        public Guid PubIdent { get; set; }
    }

    [JsonObject(IsReference = true)]
    public class Role : NonDeletableBaseModel
    {
        public string Name { get; set; }
        [JsonIgnore]
        public virtual List<User> Users { get; set; }
    }
}