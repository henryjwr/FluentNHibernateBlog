using System;

namespace MemeCreator.Classes
{
    public class Meme
    {
        public virtual Guid Id { get; set; }
        public virtual string ImagePath { get; set; }
        public virtual string TopMemeLine { get; set; }
        public virtual string BottomMemeLine { get; set; }
    }
}