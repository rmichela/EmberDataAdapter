using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.ModelBinding.Binders;
using EmberDataAdapter;
using Host.Models;
using Host.Repository;

namespace Host.Controllers
{
    public class CommentsController : EmberDataController<Comment>
    {
        private readonly IBlogRepository _repository;

        public CommentsController() : this(new BlogRepository())
        {
            
        }

        public CommentsController(IBlogRepository repository)
        {
            _repository = repository;
        }

        protected override IEnumerable<Comment> GetAll()
        {
            throw new System.NotImplementedException();
        }

        protected override Comment GetOne(int id)
        {
            return _repository.GetComment(id);
        }
    }
}