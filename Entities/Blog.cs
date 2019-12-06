using System.Collections.Generic;

namespace firstApp.Entities
{
    public class Blog
    {
        public int BlogId { get; set; }
        public string Url { get; set; }

        public List<Post> Posts { get; set; }
    }

    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        // public int BlogPostId { get; set; }
        public int BlogId { get; set; }
        // public int BlogPostId { get; set; }
        // public int BlogId{get;set;}

    }
}