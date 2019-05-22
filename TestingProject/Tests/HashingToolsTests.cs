using Blog.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingProject.Tests
{
    class HashingToolsTests
    {
        public static byte[] HashIt(string password, byte[] salt = null) =>
            password.Hash(salt);

        public static byte[] GetSalt() =>
            HashingTools.Salt ?? null;
    }
}
