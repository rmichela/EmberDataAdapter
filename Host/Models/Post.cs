using System.Collections.Generic;
using EmberDataAdapter;

namespace Host.Models
{
//    [AlternateName("Posty", "Posties")]
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
//        [Sideload]
        public IEnumerable<Comment> Comments { get; set; } 
    }
}