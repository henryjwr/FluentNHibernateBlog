using FluentNHibernate.Mapping;
using MemeCreator.Classes;

namespace MemeCreator.Maps
{
    public class UserMap : ClassMap<User>
    {
         public UserMap()
         {
             Table("Users");
             Id(x => x.Id);
             Map(x => x.UserName);
             Map(x => x.FirstName);
             Map(x => x.LastName);
         }
    }
}