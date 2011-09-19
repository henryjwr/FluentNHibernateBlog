using FluentNhibernateBlog.Domain;
using FluentNhibernateBlog.Persistence;
using Machine.Specifications.Utility.Internal;

namespace FluentNhibernateBlog
{
    class BlogBuilder
    {
        private readonly IRepository<Post> _postRepository;
        private readonly IRepository<Comment> _commentRepository;

        public BlogBuilder(IRepository<Post> postRepository, IRepository<Comment> commentRepository)
        {
            _postRepository = postRepository;
            _commentRepository = commentRepository;
        }

        public void BuildBlog()
        {
            //Create the Users
            var userOne = new BlogUser("Ninja", "Die", "Antwoord", "MulletPower");
            var userTwo = new BlogUser("JimmyNewt", "Jimmy", "Newtron", "SweetHair");
            var userThree = new BlogUser("DexterL", "Dexter", "Laboratory", "DEEDEE");

            for (int i = 1; i <= 100; i++)
            {
                var user = i%3 == 0 ? userThree : i%2 == 0 ? userTwo : userOne;
                var post = new Post(string.Format("Blog Post {0}", i), string.Format("This is post number {0} for this test blog that we are testing with", i), user);

                // Create some comments on this post
                for (int j = 1; j <= 10; j++)
                {
                    var comment = new Comment(string.Format("Post Commnent {0}", i), user);
                    post.AddComment(comment);
                    _commentRepository.Save(comment);

                }
                    // Save the post
                    _postRepository.Save(post);
            }
        }
    }
}
