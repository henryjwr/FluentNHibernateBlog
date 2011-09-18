using System;

namespace FluentNhibernateBlog.Domain
{
    public class Comment : DomainEntity
    {
        public virtual Blog Blog { get; set; }
        public virtual Post Post { get; set; }
        public virtual string UserComment { get; set; }
        public virtual User User { get; set; }

        public Comment(){}

        public Comment(Blog blog, Post post, string userComment, User user)
        {
            Blog = blog;
            Post = post;
            UserComment = userComment;
            User = user;
        }
    }
}