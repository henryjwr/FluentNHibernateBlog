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
        //private static Configuration _configuration;
        private static BlogBuilder blogBuilder;
        private static ISessionFactory factory;
        private static ISession session;

        public static void Main(string[] args)
        {
            factory = CreateSessionFactory();
            session = factory.OpenSession();
            blogBuilder = new BlogBuilder(new NHibernateRepository<Blog>(session));
                        
            //blogBuilder.BuildBlog();
            CreateBlog();

            SelectAllPostsAndCommentsWithNPlus1();
            SelectAllPostsAndCommentsNoNPlus1();

            InsertNewPost();

            FetchPostsWithPaging();

            FetchCommentsForSinglePostWIthPaging();

            Console.Write("Done");
            Console.Read();
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

        private static void CreateBlog()
        {
            using(var tempSession = factory.OpenSession())
            {
                using(var transaction = tempSession.BeginTransaction())
                {
                    //Create the Users
                    var userOne = new User("Ninja", "Die", "Antwoord", "MulletPower");
                    //var userTwo = new User("JimmyNewt", "Jimmy", "Newtron", "SweetHair");
                    //var userThree = new User("DexterL", "Dexter", "Laboratory", "DEEDEE");

                    //Create the Blogs
                    var blogOne = new Blog(userOne, "I'm a Ninja yo.  I'm in tha zone.");
                    //var blogTwo = new Blog(userTwo, "Creating funky inventions");
                    //var blogThree = new Blog(userThree, "Making sweet world dmination tools.");

                    ////Post to the first Blog
                    //var blogOnePostOne = new Post(blogOne, "Post One", "This is the first post");
                    //blogOne.AddPost(blogOnePostOne);
                    //var blogOnePostTwo = new Post(blogOne, "Post Two", "This is the Second post");
                    //blogOne.AddPost(blogOnePostTwo);
                    //var blogOnePostThree = new Post(blogOne, "Post Three", "This is the Third post");
                    //blogOne.AddPost(blogOnePostThree);
                    //var blogOnePostFour = new Post(blogOne, "Post Four", "This is the Fourth post");
                    //blogOne.AddPost(blogOnePostFour);
                    //var blogOnePostFive = new Post(blogOne, "Post Five", "This is the Fifth post");
                    //blogOne.AddPost(blogOnePostFive);
                    //var blogOnePostSix = new Post(blogOne, "Post Six", "This is the Sixth post");
                    //blogOne.AddPost(blogOnePostSix);
                    //var blogOnePostSeven = new Post(blogOne, "Post Seven", "This is the Seventh post");
                    //blogOne.AddPost(blogOnePostSeven);

                    //Comments to Blog one posts
                    //var blogOnePostOneCommentOne = new Comment(blogOne, blogOnePostOne, "This is the first comment", userOne);

                    //Update the database.
                    tempSession.SaveOrUpdate(userOne);
                    tempSession.SaveOrUpdate(blogOne);
                    transaction.Commit();
                }
                
            }
        }

        private static ISessionFactory CreateSessionFactory()
        {
            var configuration = new BlogConfiguration();
            
            var testing = Fluently
                .Configure().Database(SQLiteConfiguration.Standard.UsingFile("blogDatabase.db")) // .InMemory()
                .Mappings(m => m.AutoMappings.Add(AutoMap.AssemblyOf<Blog>(configuration))) // FluentMappings.AddFromAssemblyOf<Program>()
                //.ExposeConfiguration(cfg => _configuration = cfg)
                .BuildSessionFactory();
            return testing;
        }
    }
}
