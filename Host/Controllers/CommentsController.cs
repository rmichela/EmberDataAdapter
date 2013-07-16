using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Host.Models;
using Host.Repository;

namespace Host.Controllers
{
    public class CommentsController : ApiController
    {
        private readonly IBlogRepository _repository;

        public CommentsController() : this(new BlogRepository())
        {
            
        }

        public CommentsController(IBlogRepository repository)
        {
            _repository = repository;
        }

        public Comment Get(int id)
        {
            return _repository.GetComment(id);
        }

        public IEnumerable<Comment> Get([FromUri]List<int> ids)
        {
            return ids.Select(Get);
        }
    }
}