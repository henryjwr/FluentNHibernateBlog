namespace FluentNhibernateBlog.Actions.Blogs.Posts
{
    public class AddPostAction
    {
        public AddPostAction(){}

        public AddPostViewModel Get(AddPostRequest request)
        {
            return new AddPostViewModel();
        }
    }

    public class AddPostViewModel
    {
    }

    public class AddPostRequest
    {
    }
}