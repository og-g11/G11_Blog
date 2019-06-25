using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Blog.Domain;
using Blog.Repository;
using System.Linq.Expressions;

namespace Blogs.UnitTest
{
    [TestClass]
    public class UserRepositoryUnitTesting : RepositoryUnitTesting<User>
    {
        internal override IRepository<User> Repository => _unitOfWork.UserRepository;

        [TestMethod]
        public void UserTesting()
        {
            GetAllUserUnitTests();
            GetAllUserUnitTests();
            FindUserUnitTests();
            AddUserUnitTests();
            AddRangeUserUnitTests();
            RemoveUserUnitTests();
            RemoveRangeUserUnitTests();
            LoginUserUnitTests();
        }

        public void GetUserUnitTests()
        {
            GetUnitTesting(1);
            Assert.IsTrue(_IsRecordOperationSuccesfull, "Correct id but somethig is wrong.");

            GetUnitTesting(2);
            Assert.IsFalse(_IsRecordOperationSuccesfull, "Not correct id. somethig is wrong.");
        }
        public void GetAllUserUnitTests()
        {
            GetAllUnitTesting(true);
            Assert.IsTrue(_IsRecordOperationSuccesfull, "There are some records but somethis is wrong.");

            GetAllUnitTesting(false);
            Assert.IsFalse(_IsRecordOperationSuccesfull, "There are not records. check datasource.");
        }
        public void FindUserUnitTests()
        {
            FindUnitTest(u => u.FirstName == "Jack");
            Assert.IsTrue(_IsRecordOperationSuccesfull, "Record Exists but there is problem.");

            FindUnitTest(u => u.LastName == "Anderson");
            Assert.IsTrue(_IsRecordOperationSuccesfull, "Record Exists but there is problem.");

            FindUnitTest(u => u.Email == "J@J.mail.com");
            Assert.IsTrue(_IsRecordOperationSuccesfull, "Record Exists but there is problem.");

            FindUnitTest(u => u.FirstName == "sdfgfsfb");
            Assert.IsFalse(_IsRecordOperationSuccesfull, "Record doesn't exists. There is problem.");

            FindUnitTest(u => u.LastName == "sdfgfsfb");
            Assert.IsFalse(_IsRecordOperationSuccesfull, "Record doesn't exists. There is problem.");

            FindUnitTest(u => u.Email == "sdfgfsfb");
            Assert.IsFalse(_IsRecordOperationSuccesfull, "Record doesn't exists. There is problem.");
        }
        public void AddUserUnitTests()
        {
            AddUserTester(new User() { FirstName = "Test", LastName = "Test", Password = "TestPassword", Email = "123.mail.com" });
            Assert.IsTrue(_IsRecordOperationSuccesfull, "Not same email. There is problem");

            AddUserTester(new User() { FirstName = "Test", LastName = "Test", Password = "TestPassword", Email = "J@J.mail.com" });
            Assert.IsFalse(_IsRecordOperationSuccesfull, "Same email. There is problem");
        }
        public void AddUserTester(User user)
        {
            IEnumerable<User> users = Repository.GetAll();
            _IsRecordOperationSuccesfull = users.Where(x => x.Email == user.Email).Count() == 0;
        }
        public void AddRangeUserUnitTests()
        {
            List<User> users = new List<User>();
            users.Add(new User { FirstName = "firstname1", LastName = "lastname1", Email = "email1", DateCreated = DateTime.Now, IsDeleted = false, Password = "password1", Salt = "123" });
            users.Add(new User { FirstName = "firstname2", LastName = "lastname2", Email = "email2", DateCreated = DateTime.Now, IsDeleted = false, Password = "password2", Salt = "123" });
            users.Add(new User { FirstName = "firstname3", LastName = "lastname3", Email = "email3", DateCreated = DateTime.Now, IsDeleted = false, Password = "password3", Salt = "123" });
            AddRangeUserTester(users);
            Assert.IsTrue(_IsRecordOperationSuccesfull, "Not same emails but something is wrong");

            List<User> users2 = new List<User>();
            users2.Add(new User { FirstName = "firstname1", LastName = "lastname1", Email = "email1", DateCreated = DateTime.Now, IsDeleted = false, Password = "password1", Salt = "123" });
            users2.Add(new User { FirstName = "firstname2", LastName = "lastname2", Email = "email2", DateCreated = DateTime.Now, IsDeleted = false, Password = "password2", Salt = "123" });
            users2.Add(new User { FirstName = "firstname3", LastName = "lastname3", Email = "J@J.mail.com", DateCreated = DateTime.Now, IsDeleted = false, Password = "password3", Salt = "123" });
            AddRangeUserTester(users2);
            Assert.IsFalse(_IsRecordOperationSuccesfull, "There are some similar emails but there is problem.");
        }
        public void AddRangeUserTester(IEnumerable<User> users)
        {
            IEnumerable<User> usersInDataBase = Repository.GetAll();
            _IsRecordOperationSuccesfull = users.Where(x => usersInDataBase.Any(y => y.Email != x.Email)).Count() == users.Count();
        }
        public void RemoveUserUnitTests()
        {
            RemoveUserTester(new User
            {
                ID = 1,
                FirstName = "firstname1",
                LastName = "lastname1",
                Email = "email1",
                DateCreated = DateTime.Now,
                IsDeleted = false,
                Password = "password1",
                Salt = "123"
            });

            Assert.IsTrue(_IsRecordOperationSuccesfull, "There is record for delete but there is problem");

            RemoveUserTester(new User
            {
                ID = 2,
                FirstName = "firstname1",
                LastName = "lastname1",
                Email = "email1",
                DateCreated = DateTime.Now,
                IsDeleted = false,
                Password = "password1",
                Salt = "123"
            });

            Assert.IsFalse(_IsRecordOperationSuccesfull, "There isn,t record but somethig is wrong");
        }
        public void RemoveUserTester(User user)
        {
            IEnumerable<User> users = Repository.GetAll();
            _IsRecordOperationSuccesfull = users.Where(x => x.ID == user.ID).Count() > 0;
        }
        public void RemoveRangeUserUnitTests()
        {
            List<User> users = new List<User>();
            users.Add(new User { ID = 1, FirstName = "firstname1", LastName = "lastname1", Email = "email1", DateCreated = DateTime.Now, IsDeleted = false, Password = "password1", Salt = "123" });
            RemoveRangeUserTester(users);
            Assert.IsTrue(_IsRecordOperationSuccesfull, "There is users but somethig is wrong");

            List<User> users2 = new List<User>();
            users.Add(new User { ID = 2, FirstName = "firstname1", LastName = "lastname1", Email = "email1", DateCreated = DateTime.Now, IsDeleted = false, Password = "password1", Salt = "123" });
            RemoveRangeUserTester(users2);
            Assert.IsFalse(_IsRecordOperationSuccesfull, "There Are not elements Somethig is wrong");
        }
        public void RemoveRangeUserTester(IEnumerable<User> users)
        {
            IEnumerable<User> usersInDataBase = Repository.GetAll();
            _IsRecordOperationSuccesfull = users.Where(x => usersInDataBase.Any(y => y.ID == x.ID)).Count() > 0;
        }
        public void LoginUserUnitTests()
        {
            LoginUserTest("J@J.mail.com", "password");
            Assert.IsTrue(_IsRecordOperationSuccesfull, "Credentials correct but there is problem.");

            LoginUserTest("J@J.mail.com", "wefwef");
            Assert.IsFalse(_IsRecordOperationSuccesfull, "Password is not correct but there is problem");

            LoginUserTest("wefwefw", "password");
            Assert.IsFalse(_IsRecordOperationSuccesfull, "Email is not correct but there is problem.");
            LoginUserTest("wdfwe", "wefwefwe");
            Assert.IsFalse(_IsRecordOperationSuccesfull,"Credentials are not correct but there is problem");
        }
        public void LoginUserTest(string email, string password)
        {
            IEnumerable<User> allUsers = Repository.GetAll();
            _IsRecordOperationSuccesfull = allUsers.Where(x => x.Email == email && x.Password == password).Count() > 0;
        }
    }
}
