using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Service.Interfaces;
using Blog.Repository;
using System.Linq.Expressions;

namespace Blog.Service.Implementation {
	internal abstract class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class {
		internal IUnitOfWork _unitOfWork;

		internal abstract IRepository<TEntity> Repository { get; }

		internal BaseService(UnitOfWork unitOfWork) {
            _unitOfWork = unitOfWork;
		}

        public ITransaction BeginTransaction()
        {
            return _unitOfWork.BeginTransaction();
        }

        public virtual TEntity Get(int id) {
			return Repository.Get(id);
		}

		public virtual IEnumerable<TEntity> GetAll() {
			return Repository.GetAll();
		}

		public virtual IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate) {
			return Repository.Find(predicate);
		}

		public virtual void Add(TEntity entity) {
			Repository.Add(entity);
			_unitOfWork.SaveChanges();
		}

		public virtual void AddRange(IEnumerable<TEntity> entities) {
			Repository.AddRange(entities);
			_unitOfWork.SaveChanges();
		}

		public virtual void Remove(TEntity entity) {
			Repository.Remove(entity);
			_unitOfWork.SaveChanges();
		}

		public virtual void RemoveRange(IEnumerable<TEntity> entities) {
			Repository.RemoveRange(entities);
			_unitOfWork.SaveChanges();
		}
	}
}
