using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Domain;

namespace Blog.Service.Interfaces
{
    public interface IContentService : IBaseService<Content>
    {
        void AddPhoto(Content content, Photo photo);
    }
}
