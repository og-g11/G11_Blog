using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Blog.Domain;
using Blog.Repository;

namespace Blogs.UnitTest
{
    [TestClass]
    public class PhotoRepositoryUnitTesting : RepositoryUnitTesting<Photo>
    {
        internal override IRepository<Photo> Repository => _unitOfWork.PhotoRepository;

        [TestMethod]
        public void PhotoTesting()
        {
            GetPhotoUnitTests();
            GetAllPhotoUnitTests();
            FindPhotoUnitTests();
            AddPhotoUnitTests();
        }

        public void GetPhotoUnitTests()
        {
            GetUnitTesting(1);
            Assert.IsTrue(_IsRecordOperationSuccesfull, "Correct id but somethig is wrong.");

            GetUnitTesting(2);
            Assert.IsFalse(_IsRecordOperationSuccesfull, "Not correct id. somethig is wrong.");
        }
        public void GetAllPhotoUnitTests()
        {
            GetAllUnitTesting(true);
            Assert.IsTrue(_IsRecordOperationSuccesfull, "There are some records but somethis is wrong.");

            GetAllUnitTesting(false);
            Assert.IsFalse(_IsRecordOperationSuccesfull, "There are not records. check datasource.");
        }
        public void FindPhotoUnitTests()
        {
            FindUnitTest(p => p.OriginalFileName == "Photo1");
            Assert.IsTrue(_IsRecordOperationSuccesfull, "Record Exists but there is problem.");

            FindUnitTest(c => c.OriginalFileName== "sdfgfsfb");
            Assert.IsFalse(_IsRecordOperationSuccesfull, "Record doesn't exists. There is problem.");
        }
        public void AddPhotoUnitTests()
        {
          
        }
        public void AddPhotoTester(Content content, Photo photo)
        {
           
        }
    }
}
