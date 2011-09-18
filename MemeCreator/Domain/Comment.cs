using System;

namespace FluentNhibernateBlog.Domain
{
    public class Comment : DomainEntity
    {
        public virtual Blog Blog { get; set; }
        public virtual Post Post { get; set; }
        public virtual string UserComment { get; set; }
        public virtual BlogUser BlogUser { get; set; }

        public Comment(){}

        public Comment(Blog blog, Post post, string userComment, BlogUser blogUser)
        {
            Blog = blog;
            Post = post;
            UserComment = userComment;
            BlogUser = blogUser;
        }
    }
}