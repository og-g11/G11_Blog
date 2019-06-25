using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Repository;
using Blog.Domain;
using Blog.Service.Interfaces;
using System.Linq.Expressions;

namespace Blog.Service.Implementation {
	internal class ContentService : BaseService<Content>, IContentService
    {
        internal override IRepository<Content> Repository => _unitOfWork.ContentRepository;

        public ContentService(UnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
        public void AddPhoto(Content content, Photo photo) {
			if (photo.Type != PhotoType.Content && content.Photos.Any(x => x.Type == photo.Type)) {
				throw new Exception("Error, hello");
			}

			content.Photos.Add(photo);
		}
	}
}
