using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Repository
{
    internal class Transaction : ITransaction
    {
        private Action _commit;
        private Action _rollback;
        private Action _dispose;

        public Transaction(Action commit, Action rollback, Action dispose)
        {
            _commit = commit;
            _rollback = rollback;
            _dispose = dispose;
        }

        public void Commit()
        {
            _commit();
        }

        public void Rollback()
        {
            _rollback();
        }

        public void Dispose()
        {
            _dispose();
        }
    }
}
