using System;
using MenhirSite.Model.Interfaces;

namespace MenhirSite.Model
{
    public class DeletableBaseModel : IEntity, IAuditable
    {
        public int Id { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }

        public string ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
    }

    public class NonDeletableBaseModel : DeletableBaseModel, IDeletedOn
    {
        public DateTime? DeletedOn { get; set; }
    }
}
