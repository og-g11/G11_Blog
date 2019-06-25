using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Domain;
using Blog.Repository;

namespace Blog.Repository {
	internal class ContentRepository : Repository<Content>, IContentRepository {

		public ContentRepository(BlogDBContext context) : base(context) {

		}

		public IEnumerable<Content> GetLastContents(int count) {
			return (from c in _context.Contents orderby c.DateCreated descending select c).Take(count);
		}
	}
}