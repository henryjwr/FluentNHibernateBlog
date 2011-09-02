using FluentNHibernate.Mapping;
using FluentNhibernateBlog.Domain;

namespace FluentNhibernateBlog.Maps
{
    public class CommentMap : ClassMap<Comment>
    {
         public CommentMap()
         {
             Table("Comments");

             Id(x => x.Id);

             Map(x => x.UserComment);

             References(x => x.Blog);
             References(x => x.User);
         }
    }
}