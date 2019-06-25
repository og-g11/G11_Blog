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
	internal class CategoryService : BaseService<Category>, ICategoryService {

        public CategoryService(UnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
        internal override IRepository<Category> Repository => _unitOfWork.CategotyRepository;
	}
}
