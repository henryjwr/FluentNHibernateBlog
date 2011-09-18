//using FluentNHibernate.Mapping;
//using FluentNhibernateBlog.Domain;

//namespace FluentNhibernateBlog.Maps
//{
//    public class CommentMap : ClassMap<Comment>
//    {
//         public CommentMap()
//         {
//             Table("Comments");

//             Map(x => x.UserComment);

//             References(x => x.Blog);
//             References(x => x.User);
//         }
//    }
//}