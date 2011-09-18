using FluentNhibernateBlog.Domain;
using FluentNhibernateBlog.Persistence;

namespace FluentNhibernateBlog
{
    class BlogBuilder
    {
        private readonly IRepository<Blog> _blogService;

        public BlogBuilder(IRepository<Blog> blogService )
        {
            _blogService = blogService;
        }

        public void BuildBlog()
        {
            //Create the Users
            var userOne = new BlogUser("Ninja", "Die", "Antwoord", "MulletPower");
            var userTwo = new BlogUser("JimmyNewt", "Jimmy", "Newtron", "SweetHair");
            var userThree = new BlogUser("DexterL", "Dexter", "Laboratory", "DEEDEE");

            //Create the Blogs
            var blogOne = new Blog(userOne, "I'm a Ninja yo.  I'm in tha zone.");
            var blogTwo = new Blog(userTwo, "Creating funky inventions");
            var blogThree = new Blog(userThree, "Making sweet world dmination tools.");

            //Post to the first Blog
            var blogOnePostOne = new Post(blogOne, "Post One", "This is the first post");
            blogOne.AddPost(blogOnePostOne);
            var blogOnePostTwo = new Post(blogOne, "Post Two", "This is the Second post");
            blogOne.AddPost(blogOnePostTwo);
            var blogOnePostThree = new Post(blogOne, "Post Three", "This is the Third post");
            blogOne.AddPost(blogOnePostThree);
            var blogOnePostFour = new Post(blogOne, "Post Four", "This is the Fourth post");
            blogOne.AddPost(blogOnePostFour);
            var blogOnePostFive = new Post(blogOne, "Post Five", "This is the Fifth post");
            blogOne.AddPost(blogOnePostFive);
            var blogOnePostSix = new Post(blogOne, "Post Six", "This is the Sixth post");
            blogOne.AddPost(blogOnePostSix);
            var blogOnePostSeven = new Post(blogOne, "Post Seven", "This is the Seventh post");
            blogOne.AddPost(blogOnePostSeven);

            //Comments to Blog one posts
            var blogOnePostOneCommentOne = new Comment(blogOne, blogOnePostOne, "This is the first comment", userOne);

            //Update the database.
            _blogService.Save(blogOne);
        }
    }
}
