using System;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;

namespace FluentNhibernateBlog
{
    class Program
    {
        private static Configuration _configuration;
        private const string DbFile = "blogdatabase.db";
        private static BlogBuilder blogBuilder = new BlogBuilder();
        
        static void Main(string[] args)
        {
            var factory = CreateSessionFactory();
            var session = factory.OpenSession();
            Console.Write("Done");
            Console.Read();
                        
            blogBuilder.BuildBlog();

            SelectAllPostsAndCommentsWithNPlus1();
            SelectAllPostsAndCommentsNoNPlus1();

            InsertNewPost();

            FetchPostsWithPaging();

            FetchCommentsForSinglePostWIthPaging();
        }
        
        private static void FetchCommentsForSinglePostWIthPaging()
        {
            
        }

        private static void FetchPostsWithPaging()
        {
            
        }

        private static void InsertNewPost()
        {
            
        }

        private static void SelectAllPostsAndCommentsWithNPlus1()
        {
            
        }

        private static void SelectAllPostsAndCommentsNoNPlus1()
        {
            
        }

        private static ISessionFactory CreateSessionFactory()
        {
            var testing = Fluently
                .Configure().Database(SQLiteConfiguration.Standard.InMemory())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Program>())
                .ExposeConfiguration(cfg => _configuration = cfg)
                .BuildSessionFactory();
            return testing;
        }
    }
}
