using FluentNhibernateBlog.Actions.Blogs;
using StructureMap.AutoMocking;

namespace FluentNhibernateBlog.Tests
{
    public class CreateBlogActionTester : ContextSpecification
    {
        protected RhinoAutoMocker<CreateBlogAction> _mocks;
        protected CreateBlogAction _action;

        protected override void SetupFixtureContext()
        {
            _mocks = new RhinoAutoMocker<CreateBlogAction>();
            _action = _mocks.ClassUnderTest;
        }
    }

    public class When_a_user_wants_to_create_a_new_blog_It_should_be_created_properly : CreateBlogActionTester
    {
        protected override void BecauseOnce()
        {
            
        }
    }
}