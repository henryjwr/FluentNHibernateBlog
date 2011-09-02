using FluentNHibernate.Mapping;
using FluentNhibernateBlog.Domain;

namespace FluentNhibernateBlog.Maps
{
    public class PostMap : ClassMap<Post>
    {
         public PostMap()
         {
             Table("Posts");

             Id(x => x.Id);

             Map(x => x.PostTitle);
             Map(x => x.PostInfo);
             Map(x => x.PostCreatedDate);

             References(x => x.Blog);
             References(x => x.User);
         }
    }
}