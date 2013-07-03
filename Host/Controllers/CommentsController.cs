using System.Collections.Generic;
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

        public IEnumerable<Comment> Get()
        {
            return _repository.GetComments();
        }

        public Comment Get(int id)
        {
            return _repository.GetComment(id);
        }
    }
}