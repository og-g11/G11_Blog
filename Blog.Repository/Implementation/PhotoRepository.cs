using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Domain;

namespace Blog.Repository
{
    internal  class PhotoRepository : Repository<Photo>, IPhotoRepository
    {
        public PhotoRepository(BlogDBContext context) : base(context)
        {

        }
    }
}
