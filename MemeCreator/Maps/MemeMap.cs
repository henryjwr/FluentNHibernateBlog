using FluentNHibernate.Mapping;
using MemeCreator.Classes;

namespace MemeCreator.Maps
{
    public class MemeMap : ClassMap<Meme>
    {
         public MemeMap()
         {
             Table("Memes");
             Id(x => x.Id);
             Map(x => x.ImagePath);
             Map(x => x.TopMemeLine);
             Map(x => x.BottomMemeLine);
         }
    }
}