using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Domain;
using System.Linq.Expressions;
using Blog.Service.Interfaces;
using Blog.Repository;

namespace Blog.Service.Implementation {
	internal class ContentTypeService : BaseService<ContentType>, IContentTypeService
    {
        public ContentTypeService(UnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
        internal override IRepository<ContentType> Repository => _unitOfWork.ContentTypeRepository;
    }
}
