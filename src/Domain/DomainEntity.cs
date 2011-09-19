using System;

namespace FluentNhibernateBlog.Domain
{
    public abstract class DomainEntity
    {
        public virtual int Id { get; set; }
        public virtual DateTime CreatedDate { get; set; }

        public DomainEntity()
        {
            CreatedDate = DateTime.Now;
        }
    }
}