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
	internal class UserService : BaseService<User>, IUserService
    {
        public UserService(UnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
        internal override IRepository<User> Repository => _unitOfWork.UserRepository;
    }
}
