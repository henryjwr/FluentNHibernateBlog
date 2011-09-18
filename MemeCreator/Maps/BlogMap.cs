//using FluentNHibernate.Mapping;
//using FluentNhibernateBlog.Domain;

//namespace FluentNhibernateBlog.Maps
//{
//    public class BlogMap : ClassMap<Blog>
//    {
//        public BlogMap()
//        {
//            Table("Blog");

//            Map(x => x.BlogTitle);

//            HasMany(x => x.GetPosts()).Cascade.All();
//            HasMany(x => x.GetComments()).Cascade.All();
//        }
//    }
//}