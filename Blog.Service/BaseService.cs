using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Repository;
namespace Blog.Service
{
    public abstract class BaseService : UnitOfWork
    {
        protected BaseService (BlogDBContext context) : base(context)
        {
           
        }

      

        protected BlogDBContext context { get { return context as BlogDBContext; } }
    }
}
