using System;

namespace FluentNhibernateBlog.Domain
{
    public abstract class DomainEntity
    {
        public virtual Guid Id { get; set; }
        public virtual DateTime CreatedDate { get; set; }

        public DomainEntity()
        {
            CreatedDate = DateTime.Now;
        }
    }
}