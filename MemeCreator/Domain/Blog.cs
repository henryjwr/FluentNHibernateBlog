using System;
using System.Collections.Generic;

namespace FluentNhibernateBlog.Domain
{
    public class Blog
    {
        public virtual Guid Id { get; set; }
        public virtual IList<Post> _posts { get; protected set; }
        public virtual IList<Comment> _comments { get; protected set; }
        public virtual User User { get; set; }
        public virtual string BlogTitle { get; set; }

        public virtual void AddPost(Post post)
        {
            post.Blog = this;
            _posts.Add(post);
        }

        public virtual void AddComment(Comment comment)
        {
            comment.Blog = this;
            _comments.Add(comment);
        }

        public Blog()
        {
            _posts = new List<Post>();
            _comments = new List<Comment>();
        }

        public virtual IList<Post> GetPosts()
        {
            return _posts;
        }

        public virtual IList<Comment> GetComments()
        {
            return _comments;
        }
    }
}