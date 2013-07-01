using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Host.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public IEnumerable<Comment> Comments { get; set; } 
    }
}