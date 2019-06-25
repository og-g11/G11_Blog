using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Service.Interfaces;
using Blog.Repository;

namespace Blog.Service.Implementation
{
    public class ServiceProvider : IDisposable
    {
        private UnitOfWork _unitOfWork;
        private Lazy<ContentService> _contentService;
        private Lazy<UserService> _userService;
        private Lazy<CategoryService> _categoryService;
        private Lazy<CommentService> _commentService;
        private Lazy<ContentTypeService> _contentTypeService;
        private Lazy<PhotoService> _photoService;
        public ServiceProvider()
        {
            if (_unitOfWork == null)
            {
                _unitOfWork = new UnitOfWork();
            }

            _contentService = new Lazy<ContentService>(() => new ContentService(_unitOfWork));
            _userService = new Lazy<UserService>(() => new UserService(_unitOfWork));
            _categoryService = new Lazy<CategoryService>(() => new CategoryService(_unitOfWork));
            _commentService = new Lazy<CommentService>(() => new CommentService(_unitOfWork));
            _contentTypeService = new Lazy<ContentTypeService>(() => new ContentTypeService(_unitOfWork));
            _photoService = new Lazy<PhotoService>(() => new PhotoService(_unitOfWork));
        }

        public IContentService ContentService => _contentService.Value;
        public IUserService UserService => _userService.Value;
        public ICategoryService CategoryService => _categoryService.Value;
        public ICommentService CommentService => _commentService.Value;
        public IContentTypeService ContentTypeService => _contentTypeService.Value;
        public IPhotoService PhotoService => _photoService.Value;

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }
    }
}
