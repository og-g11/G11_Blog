using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq.Expressions;
using Blog.Repository;

namespace Blogs.UnitTest
{
   
    public abstract class RepositoryUnitTesting<TEntity> where TEntity : class
    {
        internal readonly UnitOfWork _unitOfWork = new UnitOfWork();
        internal abstract IRepository<TEntity> Repository { get; }
        internal bool _IsRecordOperationSuccesfull;


        public virtual void GetUnitTesting(int id)
        {
            _IsRecordOperationSuccesfull = Repository.Get(id) == null ? false : true;
        }

        public void GetAllUnitTesting(bool isRecordInBase)
        {
            _IsRecordOperationSuccesfull = Repository.GetAll().Count() > 0 && isRecordInBase;
        }

        public void FindUnitTest(Expression<Func<TEntity, bool>> predicate)
        {
            _IsRecordOperationSuccesfull = Repository.Find(predicate).Count() > 0;
        }
    }
}
