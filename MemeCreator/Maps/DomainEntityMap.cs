using FluentNHibernate.Mapping;
using FluentNhibernateBlog.Domain;

namespace FluentNhibernateBlog.Maps
{
    public class DomainEntityMap : ClassMap<DomainEntity>
    {
        public DomainEntityMap()
        {
            Id(x => x.Id);

            Map(x => x.CreatedDate);
        }
    }
}