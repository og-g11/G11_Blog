using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Blog.Domain;
namespace Blog.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(BlogDBContext context) : base(context)
        {

        }

        public User GetUserWithContents(int id)
        {
            return BlogDBContext.Users.Include(u => u.Contents).SingleOrDefault(u => u.ID == id);
        }

        public BlogDBContext BlogDBContext
        {
            get { return Context as BlogDBContext; }
        }
    }
}
