//using FluentNHibernate.Mapping;
//using FluentNhibernateBlog.Domain;

//namespace FluentNhibernateBlog.Maps
//{
//    public class PostMap : ClassMap<Post>
//    {
//         public PostMap()
//         {
//             Table("Posts");

//             Map(x => x.PostTitle);
//             Map(x => x.PostInfo);

//             References(x => x.Blog);
//             References(x => x.User);
//         }
//    }
//}