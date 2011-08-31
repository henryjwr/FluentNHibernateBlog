using System;

namespace MemeCreator.Classes
{
    public class Comment
    {
        public virtual Guid Id { get; set; }
        public virtual string UserComment { get; set; }
        public virtual User User { get; set; }

        public Comment(){}
    }
}