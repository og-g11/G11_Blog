using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Domain;

namespace Blog.Repository
{
    internal class ContentTypeRepository : Repository<ContentType>, IContentTypeRepository
    {
        public ContentTypeRepository(BlogDBContext context) : base(context)
        {

        }
    }
}
