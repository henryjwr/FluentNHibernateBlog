namespace FluentNhibernateBlog.Domain
{
    public class Post
    {
        public virtual Blog Blog { get; set; }
        public virtual string PostTitle { get; set; }
        public virtual string PostInfo { get; set; }
        public virtual User User { get; set; }

        public Post(){}
    }
}