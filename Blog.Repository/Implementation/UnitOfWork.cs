using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Repository;
namespace Blog.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BlogDBContext _context;

        public UnitOfWork(BlogDBContext context)
        {
            _context = context;
            Contents = new ContentRepository(_context);
            Users = new UserRepository(_context);
        }

        public IContentRepository Contents { get; private set;}
        public IUserRepository Users { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
