using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Repository;
using System.Data.Entity;
using Blog.Logger;

namespace Blog.Repository {
	public class UnitOfWork : IUnitOfWork {
		private static BlogDBContext _context;
		//private readonly BlogDBContext _context;
		private Lazy<IUserRepository> _userRepository;
		private Lazy<IContentRepository> _contentRepository;
		private Lazy<ICategoryRepository> _categoryRepository;
		private Lazy<ICommentRepository> _commentRepository;
		private Lazy<IContentTypeRepository> _contentTypeRepository;
		private Lazy<IPhotoRepository> _photoRepository;

		public UnitOfWork() {
            if (_context == null)
            {
                _context = new BlogDBContext();
            }
            _userRepository = new Lazy<IUserRepository>(() => new UserRepository(_context));
			_contentRepository = new Lazy<IContentRepository>(() => new ContentRepository(_context));
			_categoryRepository = new Lazy<ICategoryRepository>(() => new CategoryRepository(_context));
			_commentRepository = new Lazy<ICommentRepository>(() => new CommentRepository(_context));
			_contentTypeRepository = new Lazy<IContentTypeRepository>(() => new ContentTypeRepository(_context));
			_photoRepository = new Lazy<IPhotoRepository>(() => new PhotoRepository(_context));
		}

		public IContentRepository ContentRepository => _contentRepository.Value;
		public IUserRepository UserRepository => _userRepository.Value;
		public ICategoryRepository CategotyRepository => _categoryRepository.Value;
		public ICommentRepository CommentRepository => _commentRepository.Value;
		public IContentTypeRepository ContentTypeRepository => _contentTypeRepository.Value;
		public IPhotoRepository PhotoRepository => _photoRepository.Value;

		public ITransaction BeginTransaction() {
			var transaction = _context.Database.BeginTransaction();
			void commit() => transaction.Commit();
			void rollback() => transaction.Rollback();
			void dispose() => transaction.Dispose();

			return new Transaction(commit, rollback, dispose);
		}

		public void SaveChanges() {
			try {
				using (var transaction = _context.Database.BeginTransaction()) {
					try {
						_context.SaveChanges();
						transaction.Commit();
					} catch {
						transaction.Rollback();
					}
				}
			} catch (Exception exception) {
				DataLogger.Log(exception.Message);
			} finally {
				_context.Dispose();
			}
		}

		public void Dispose() {
			_context.Dispose();
		}
	}
}
