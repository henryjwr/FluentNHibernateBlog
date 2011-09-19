using System.Collections.Generic;

namespace FluentNhibernateBlog.Domain
{
    public class Post : DomainEntity
    {
        public virtual string PostTitle { get; set; }
        public virtual string PostInfo { get; set; }
        public virtual BlogUser BlogUser { get; set; }
        public virtual IList<Comment> Comments { get; set; }

        public Post(){}

        public Post(string title, string info, BlogUser user)
        {
            PostTitle = title;
            PostInfo = info;
            BlogUser = user;
            Comments = new List<Comment>();
        }

        public virtual void AddComment(Comment comment)
        {
            comment.Post = this;
            Comments.Add(comment);
        }
    }
}