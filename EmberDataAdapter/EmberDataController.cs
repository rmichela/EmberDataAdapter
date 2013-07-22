using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace EmberDataAdapter
{
    public abstract class EmberDataController<T> : ApiController
    {
        protected abstract IEnumerable<T> GetAll();
        protected abstract T GetOne(int id);

        [HttpGet]
        public T Get(int id)
        {
            return GetOne(id);
        }

        [HttpGet]
        public IEnumerable<T> Get([FromUri] int[] ids)
        {
            if (ids == null || ids.Length == 0)
            {
                return GetAll();
            }
            return GetSome(ids);
        }

        protected virtual IEnumerable<T> GetSome(int[] ids)
        {
            return ids.Select(GetOne);
        }
    }
}
