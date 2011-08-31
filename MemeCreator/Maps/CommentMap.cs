using FluentNHibernate.Mapping;
using MemeCreator.Classes;

namespace MemeCreator.Maps
{
    public class CommentMap : ClassMap<Comment>
    {
         public CommentMap()
         {
             Table("Comments");
             Id(x => x.Id);
             Map(x => x.UserComment);
         }
    }
}