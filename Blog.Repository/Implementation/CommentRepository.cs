using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Domain;

namespace Blog.Repository
{
    internal class CommentRepository : Repository<Comment>, ICommentRepository
    {
        public CommentRepository(BlogDBContext context) : base(context)
        {

        }
    }
}
