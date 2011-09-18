using System;

namespace FluentNhibernateBlog.Domain
{
    public class Comment : DomainEntity
    {
        public virtual Blog Blog { get; set; }
        public virtual string UserComment { get; set; }
        public virtual User User { get; set; }

        public Comment(){}

        public Comment(Blog blog, string userComment, User user)
        {
            Blog = blog;
            UserComment = userComment;
            User = user;
        }
    }
}