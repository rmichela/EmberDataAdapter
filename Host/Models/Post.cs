using System.Collections.Generic;
using EmberDataAdapter;

namespace Host.Models
{
    [EdAlternatePluralization("Posties")]
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
//        [EdSideload]
        public IEnumerable<Comment> Comments { get; set; } 
    }
}