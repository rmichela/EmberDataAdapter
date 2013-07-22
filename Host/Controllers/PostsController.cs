using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using EmberDataAdapter;
using Host.Models;
using Host.Repository;

namespace Host.Controllers
{
    public class PostsController : EmberDataController<Post>
    {
        private readonly IBlogRepository _repository;

        public PostsController() : this(new BlogRepository())
        {
            
        }

        public PostsController(IBlogRepository repository)
        {
            _repository = repository;
        }

        // GET api/posts
        protected override IEnumerable<Post> GetAll()
        {
            return _repository.GetPosts();
        }

        // GET api/posts/5
        protected override Post GetOne(int id)
        {
            var post = _repository.GetPost(id);
            if (post != null)
            {
                return post;
            }
            throw new HttpResponseException(HttpStatusCode.NotFound);
        }
    }
}
