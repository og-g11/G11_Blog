﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Repository
{
    public interface ITransaction : IDisposable
    {
        void Commit();
        void Rollback();
    }
}
