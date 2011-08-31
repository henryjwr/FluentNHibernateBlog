using System;

namespace MemeCreator.Classes
{
    public class Post
    {
        public virtual Guid Id { get; set; }
        public virtual string PostTitle { get; set; }
        public virtual string PostInfo { get; set; }
        public virtual User User { get; set; }

        public Post(){}
    }
}