using System;

namespace FluentNhibernateBlog.Domain
{
    public class User
    {
        public virtual Guid Id { get; set; }
        public virtual Blog Blog { get; set; }
        public virtual string UserName { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }

        public User() { }
    }
}