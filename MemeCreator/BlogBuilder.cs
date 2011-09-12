using FluentNhibernateBlog.Domain;

namespace FluentNhibernateBlog
{
    class BlogBuilder
    {
        public BlogBuilder() {}

        public void BuildBlog()
        {
            //Create the Users
            var userOne = new User("Ninja", "Die", "Antwoord", "MulletPower");
            var userTwo = new User("MikeL", "Mike", "Lebowsky", "54321");
            var userThree = new User("JimmyNewt", "Jimmy", "Newtron", "SweetHair");
            var userFour = new User("DexterL", "Dexter", "Laboratory", "DEEDEE");

            //Create the Blogs
            var blogOne = new Blog(userOne, "I'm a Ninja yo.  I'm in tha zone.");
            var blogTwo = new Blog(userTwo, "Scaring Kids");
            var blogThree = new Blog(userThree, "Creating funky inventions");
            var blogFour = new Blog(userFour, "Making sweet world dmination tools.");

            //Post to the Blogs
            var blogOnePostOne = new Post(blogOne, "", "");
        }
    }
}
