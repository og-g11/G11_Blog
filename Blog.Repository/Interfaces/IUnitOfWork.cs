using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Repository;
namespace Blog.Repository
{
    interface IUnitOfWork : IDisposable
    {
        IContentRepository Contents{ get; }

        IUserRepository Users { get; }

        int Complete();
    }
}
