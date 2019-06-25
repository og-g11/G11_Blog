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
	internal class CommentService : BaseService<Comment>, ICommentService
    {
        public CommentService(UnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
        internal override IRepository<Comment> Repository => _unitOfWork.CommentRepository;
    }
}
