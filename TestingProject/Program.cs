using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingProject.Tests;

namespace Blog.Test {
	class Program {
		#region Properties

		private const string Password1 = "ooRaKaiLobioa60";
		private const string Password2 = "ooRaKaiLobioa61";

		private static byte[] Salt { get; set; }

		#endregion

		static void Main(string[] args) {
			PasswordManipulation();

			Console.ReadKey();
		}

		#region Password_Tests_Init

		static void PasswordManipulation() {
			byte[] pwd1 = PasswordHashing(Password1);

			byte[] pwd2 = PasswordHashing(Password2, Salt);

			if (HashComparator(pwd1, pwd2))
				Console.WriteLine("hashes match");
			else
				Console.WriteLine("they dont match");
		}

		static bool HashComparator(byte[] a, byte[] b) => a.SequenceEqual(b);

		static byte[] PasswordHashing(string password, byte[] saltFromOutside = null) {
			byte[] hashedRaw;

			hashedRaw = HashingToolsTests.HashIt(password, saltFromOutside);

			Salt = HashingToolsTests.GetSalt();
			return hashedRaw;
		}

		#endregion

	}
}
