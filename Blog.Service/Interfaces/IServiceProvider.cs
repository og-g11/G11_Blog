using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Service.Interfaces
{
    public interface IServiceProvider
    {
        IContentService ContentService { get; }

        IUserService UserService { get; }

        ICategoryService CategoryService { get; }

        ICommentService CommentService { get; }

        IContentTypeService ContentTypeService { get; }

        IPhotoService PhotoService { get; }

    }
}
