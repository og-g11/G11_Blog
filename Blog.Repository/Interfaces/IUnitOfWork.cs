using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Repository;

namespace Blog.Repository {
	public interface IUnitOfWork : IDisposable {
		IContentRepository ContentRepository { get; }

		IUserRepository UserRepository { get; }

        ICommentRepository CommentRepository { get; }

        IContentTypeRepository ContentTypeRepository { get; }

        IPhotoRepository PhotoRepository { get; }

        ICategoryRepository CategotyRepository { get; }

        ITransaction BeginTransaction();

		void SaveChanges();
	}
}
