using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Host.Models;

namespace Host.Controllers
{
    public class PostsController : ApiController
    {
        private IRepository _repository;

        public PostsController() : this(new Repository())
        {
            
        }

        public PostsController(IRepository repository)
        {
            _repository = repository;
        }

        // GET api/posts
        public IEnumerable<Post> Get()
        {
            return _repository.GetPosts();
        }

        // GET api/posts/5
        public Post Get(int id)
        {
            var post = _repository.GetPost(id);
            if (post != null)
            {
                return post;
            }
            throw new HttpResponseException(HttpStatusCode.NotFound);
        }

        // POST api/posts
        public void Post([FromBody]Post value)
        {
            _repository.AddPost(value);
        }

        // PUT api/posts/5
        public void Put(int id, [FromBody]Post value)
        {
            _repository.UpdatePost(id, value);
        }

        // DELETE api/posts/5
        public void Delete(int id)
        {
            _repository.DeletePost(id);
        }
    }
}
