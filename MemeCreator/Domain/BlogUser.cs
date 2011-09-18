namespace FluentNhibernateBlog.Domain
{
    public class BlogUser : DomainEntity
    {
        public virtual Blog Blog { get; set; }
        public virtual string UserName { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string Password { get; set; }

        public BlogUser() { }

        public BlogUser(string userName, string firstName, string lastName, string password)
        {
            UserName = userName;
            FirstName = firstName;
            LastName = lastName;
            Password = password;
        }
    }
}