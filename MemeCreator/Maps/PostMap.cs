using FluentNHibernate.Mapping;
using MemeCreator.Classes;

namespace MemeCreator.Maps
{
    public class PostMap : ClassMap<Post>
    {
         public PostMap()
         {
             Table("Posts");
             Id(x => x.Id);
             Map(x => x.PostTitle);
             Map(x => x.PostInfo);

         }
    }
}