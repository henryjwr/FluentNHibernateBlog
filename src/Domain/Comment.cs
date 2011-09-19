using System;

namespace FluentNhibernateBlog.Domain
{
    public class Comment : DomainEntity
    {
        public virtual Post Post { get; set; }
        public virtual string UserComment { get; set; }
        public virtual BlogUser BlogUser { get; set; }

        public Comment(){}

        public Comment(string userComment, BlogUser blogUser)
        {
            UserComment = userComment;
            BlogUser = blogUser;
        }
    }
}