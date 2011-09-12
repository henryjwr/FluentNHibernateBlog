using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNhibernateBlog.Domain;

namespace FluentNhibernateBlog
{
    class BlogBuilder
    {
        public BlogBuilder() {}

        public void BuildBlog()
        {
            var userOne = new User("SBSteve", "Steve", "SB", "12345");
            var userTwo = new User("MikeL", "Mike", "Lebowsky", "54321");
            var userThree = new User("JimmyNewt", "Jimmy", "Newtron", "SweetHair");
            var userFour = new User("DexterL", "Dexter", "Laboratory", "DEEDEE");
            var userFive = new User("Ninja", "Die", "Antwoord", "MulletPower");

            var blogOne = new Blog(userOne, "Plaid Hat");
            var blogTwo = new Blog(userTwo, "Scaring Kids");
            var blogThree = new Blog(userThree, "Creating funky inventions");
            var blogFour = new Blog(userFour, "Making sweet world dmination tools.");
            var blogFive = new Blog(userFive, "I'm a Ninja yo.  I'm in tha zone.");


        }
    }
}
