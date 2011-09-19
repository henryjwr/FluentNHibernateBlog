using System;
using System.IO;
using System.Linq;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Conventions.Helpers;
using FluentNhibernateBlog.Domain;
using FluentNhibernateBlog.Persistence;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Linq;
using NHibernate.Tool.hbm2ddl;
using NHibernate.Transform;

namespace FluentNhibernateBlog
{
    public class Program
    {
        private static BlogBuilder blogBuilder;
        private static ISessionFactory factory;
        private static string DbFile = "blogDatabase.db";

        private static bool isNewDatabase = false;

        public static void Main(string[] args)
        {
            HibernatingRhinos.Profiler.Appender.NHibernate.NHibernateProfiler.Initialize();

            factory = CreateSessionFactory();

            if (isNewDatabase)
            {
                PopulateDatabase();
                return;
            }

            //SelectAllPostsAndCommentsWithNPlus1();
            //SelectAllPostsAndCommentsNoNPlus1();

            //SelectFirstPageOfPostsWithTotalPostCount();
            //SelectFirstPageOfPostsWithTotalPostCountNoErrors();


            GetPostAndCommentCountsForEachUser();
            GetSinglePageOfPostsForUserWithCommentCountForEachPost();
            //FetchPostsWithPaging();

            //FetchCommentsForSinglePostWIthPagingLinq();

            Console.Write("Done");
            Console.Read();
        }

        private static void GetPostAndCommentCountsForEachUser()
        {
            using (var sess = factory.OpenSession())
            {
                var blogUsers = sess.QueryOver<BlogUser>().Take(15).Future();

                foreach (var user in blogUsers)
                {
                    var postCount = sess.QueryOver<Post>().Where(x => x.BlogUser.Id == user.Id).RowCount();

                    //foreach (var post in posts)
                    //{
                    //    Console.WriteLine(string.Format("Title: {0} Comments: {3} - User: {1} - Text: {2}", post.PostTitle, post.PostInfo, post.BlogUser.FirstName, post.Comments.Count));
                    //}

                    var commentCount = sess.QueryOver<Comment>().Where(x => x.BlogUser.Id == user.Id).RowCount();

                    //foreach (var comment in comments)
                    //{
                    //    Console.WriteLine(string.Format("Post: {0} Comment: {1} - User: {2}", comment.Post, comment.UserComment, comment.BlogUser.FirstName));
                    //}

                    Console.WriteLine(string.Format("Total Number of Posts: {0} - Comments: {1}", postCount, commentCount));
                }
                //var totalUserPosts = sess.Query<Post>().Count();

                //Console.WriteLine(string.Format("Total Number of Posts: {0}", totalUserPosts));
            }
        }

        private static void GetSinglePageOfPostsForUserWithCommentCountForEachPost()
        {

            using (var sess = factory.OpenSession())
            {
                var users = sess.Query<BlogUser>().ToList();
                var blogUser = sess.Get<BlogUser>(users.First().Id);

                PostDTO postDto = null;
                BlogUser userAlias = null;

                var userSinglePagePosts = sess.QueryOver<Post>()
                    .Where(p => p.BlogUser.Id == blogUser.Id)
                    .Inner.JoinQueryOver(post => post.BlogUser, () => userAlias)
                    .SelectList(list => list
                                .Select(p => p.PostTitle).WithAlias(() => postDto.Title)
                                .Select(p => p.PostInfo).WithAlias(() => postDto.Text)
                                .Select(p => p.CreatedDate).WithAlias(() => postDto.Date)
                                //.SelectSum(p => p.Comments).WithAlias(() => postDto.CommentCount)
                                .Select(p => userAlias.FirstName).WithAlias(() => postDto.Username)
                             )
                        .TransformUsing(Transformers.AliasToBean<PostDTO>())
                        .Take(15)
                        .Future<PostDTO>();

                foreach (var post in userSinglePagePosts)
                {
                    Console.WriteLine(string.Format("Title: {0} Comments: {3} - User: {1} - Text: {2}", post.Title, post.Username, post.Text, post.CommentCount));
                }
            }
        }

        private static void SelectFirstPageOfPostsWithTotalPostCount()
        {
            using (var sess = factory.OpenSession())
            {
                var posts = sess.Query<Post>().Take(15).ToList();

                foreach (var post in posts)
                {
                    Console.WriteLine(string.Format("Title: {0} Comments: {3} - User: {1} - Text: {2}", post.PostTitle, post.PostInfo, post.BlogUser.FirstName, post.Comments.Count));
                }

                var totalPosts = sess.Query<Post>().Count();

                Console.WriteLine(string.Format("Total Number of Posts: {0}", totalPosts));
            }
        }

        private static void SelectFirstPageOfPostsWithTotalPostCountNoErrors()
        {
            using (var sess = factory.OpenSession())
            {
                var posts = sess.QueryOver<Post>().Fetch(x => x.Comments).Eager.Take(15).Future();

                foreach (var post in posts)
                {
                    Console.WriteLine(string.Format("Title: {0} Comments: {3} - User: {1} - Text: {2}", post.PostTitle, post.PostInfo, post.BlogUser.FirstName, post.Comments.Count));
                }

                var totalPosts = sess.Query<Post>().ToFutureValue();

                Console.WriteLine(string.Format("Total Number of Posts: {0}", totalPosts));
            }
        }

        private static void FetchCommentsForSinglePostWIthPagingLinq()
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
            using (var sess = factory.OpenSession())
            {
                var posts = sess.Query<Post>();

                foreach (var post in posts)
                {
                    Console.WriteLine(string.Format("Title: {0} Comments: {3} - User: {1} - Text: {2}", post.PostTitle, post.PostInfo, post.BlogUser.FirstName, post.Comments.Count));
                }
            }
        }

        private static void SelectAllPostsAndCommentsNoNPlus1()
        {
            using (var sess = factory.OpenSession())
            {
                var posts = sess.QueryOver<Post>()
                    .Fetch(x => x.Comments).Eager
                    .List();

                foreach (var post in posts)
                {
                    Console.WriteLine(string.Format("Title: {0} Comments: {3} - User: {1} - Text: {2}", post.PostTitle, post.PostInfo, post.BlogUser.FirstName, post.Comments.Count));
                }
            }
        }

        private static void PopulateDatabase()
        {
            using (var sess = factory.OpenSession())
            {
                using (var trans = sess.BeginTransaction())
                {
                    try
                    {
                        blogBuilder = new BlogBuilder(new NHibernateRepository<Post>(sess), new NHibernateRepository<Comment>(sess));
                        blogBuilder.BuildBlog();
                        trans.Commit();
                    }
                    catch (Exception)
                    {
                        trans.Rollback();
                        throw;
                    }
                }
            }
        }

        private static ISessionFactory CreateSessionFactory()
        {
            var configuration = new BlogConfiguration();

            var testing = Fluently
                .Configure().Database(SQLiteConfiguration.Standard.UsingFile(DbFile))

                .Mappings(m => m.AutoMappings.Add(
                    AutoMap.AssemblyOf<Post>(configuration)
                    .Conventions.Add(Table.Is(x => x.EntityType.Name + "Table"))
                    .Conventions.Add(DefaultCascade.All())
                    .Conventions.Add(PrimaryKey.Name.Is(x => "Id"))
                    .Conventions.Add(ConventionBuilder.Id.Always(id => id.GeneratedBy.Increment()))
                        ))
                .ExposeConfiguration(BuildSchema)
                .BuildSessionFactory();
            return testing;
        }

        private static void BuildSchema(Configuration obj)
        {
            if (!isNewDatabase) return;

            if (File.Exists(DbFile))
                File.Delete(DbFile);

            new SchemaExport(obj).Create(false, true);
        }
    }

    internal class PostDTO
    {
        public virtual string Title { get; set; }
        public virtual string Text { get; set; }
        public virtual string Username { get; set; }
        public virtual int CommentCount { get; set; }

        public DateTime Date { get; set; }
    }
}
