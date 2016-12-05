using System;

namespace Mess.Models
{
    public class Post
    {
        public int Id;
        public string Title, Body, FriendlyUrlTitle;
        public DateTime PublishDate, UnpublishDate;
    }
}