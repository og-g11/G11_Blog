using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Domain;
using Blog.Repository;

namespace Blog.Repository
{
    public class ContentRepository : Repository<Content>, IContentRepository
    {

        public ContentRepository(BlogDBContext context) : base(context)
        {

        }

        public IEnumerable<Content> GetLastContents(int count)
        {
            return (from c in BlogDBContext.Contents orderby c.DateCreated descending select c).Take(count);
        }

        public BlogDBContext BlogDBContext
        {
            get {return Context as BlogDBContext;}
        }
    }
}
