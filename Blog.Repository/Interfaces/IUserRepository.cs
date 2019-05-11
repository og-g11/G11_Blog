﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Domain;
namespace Blog.Repository
{
   public interface IUserRepository : IRepository<User>
    {
        User GetUserWithContents(int id);
    }
}