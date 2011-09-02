namespace FluentNhibernateBlog.Domain
{
    public class User : DomainEntity
    {
        public virtual Blog Blog { get; set; }
        public virtual string UserName { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string Password { get; set; }

        public User() { }

        public User(string userName, string firstName, string lastName, string password)
        {
            UserName = userName;
            FirstName = firstName;
            LastName = lastName;
            Password = password;
        }
    }
}