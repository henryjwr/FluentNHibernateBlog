using System;

namespace FluentNhibernateBlog.Domain
{
    public class Comment
    {
        public virtual Guid Id { get; set; }
        public virtual Blog Blog { get; set; }
        public virtual string UserComment { get; set; }
        public virtual User User { get; set; }

        public Comment(){}
    }
}