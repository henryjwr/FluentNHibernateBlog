using System;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNhibernateBlog.Domain;
using FluentNhibernateBlog.Persistence;
using NHibernate;
using NHibernate.Cfg;

namespace FluentNhibernateBlog
{
    public class Program
    {
        private static Configuration _configuration;
        private const string DbFile = "blogdatabase.db";
        private static BlogBuilder blogBuilder;
        
        public static void Main(string[] args)
        {
            var factory = CreateSessionFactory();
            var session = factory.OpenSession();
            blogBuilder = new BlogBuilder(new NHibernateRepository<Blog>(session));
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
            var configuration = new BlogConfiguration();
            
            var testing = Fluently
                .Configure().Database(SQLiteConfiguration.Standard.UsingFile("blogDatabase.db")) // .InMemory()
                .Mappings(m => m.AutoMappings.Add(AutoMap.AssemblyOf<Blog>(configuration))) // FluentMappings.AddFromAssemblyOf<Program>()
                .ExposeConfiguration(cfg => _configuration = cfg)
                
                .BuildSessionFactory();
            return testing;
        }
    }
}
