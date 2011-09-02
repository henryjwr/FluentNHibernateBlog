using FluentNHibernate.Mapping;
using FluentNhibernateBlog.Domain;

namespace FluentNhibernateBlog.Maps
{
    public class UserMap : ClassMap<User>
    {
         public UserMap()
         {
             Table("Users");

             Map(x => x.UserName);
             Map(x => x.FirstName);
             Map(x => x.LastName);

             References(x => x.Blog);
         }
    }
}