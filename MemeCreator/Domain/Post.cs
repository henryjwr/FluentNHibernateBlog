namespace FluentNhibernateBlog.Domain
{
    public class Post
    {
        public virtual Blog Blog { get; set; }
        public virtual string PostTitle { get; set; }
        public virtual string PostInfo { get; set; }
        public virtual User User { get; set; }

        public Post(){}

        public Post(Blog blog, string title, string info)
        {
            Blog = blog;
            PostTitle = title;
            PostInfo = info;
            User = blog.User;
        }
    }
}