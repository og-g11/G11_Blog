using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Blog.Domain;

namespace Blog.Repository {
	internal class UserRepository : Repository<User>, IUserRepository {
		public UserRepository(BlogDBContext context) : base(context) {

		}

		public User GetUserWithContents(int id) {
			return _context.Users.Include(u => u.Contents).SingleOrDefault(u => u.ID == id);
		}
	}
}