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
    public class ContentRepositoryUnitTesting : RepositoryUnitTesting<Content>
    {
        internal override IRepository<Content> Repository => _unitOfWork.ContentRepository;
        [TestMethod]
        public void ContentTesting()
        {
            GetContentUnitTest();
            GetAllContentUnitTest();
            FindContentUnitTest();
            AddContentUnitTest();
            AddRangeContentUnitTests();
            RemoveContentUnitTests();
            RemoveRangeContentUnitTests();

        }

        public void GetContentUnitTest()
        {
            GetUnitTesting(1);
            Assert.IsTrue(_IsRecordOperationSuccesfull, "Correct id but somethig is wrong.");

            GetUnitTesting(2);
            Assert.IsFalse(_IsRecordOperationSuccesfull, "Not correct id. somethig is wrong.");
        }
        public void GetAllContentUnitTest()
        {
            GetAllUnitTesting(true);
            Assert.IsTrue(_IsRecordOperationSuccesfull, "There are some records but somethis is wrong.");

            GetAllUnitTesting(false);
            Assert.IsFalse(_IsRecordOperationSuccesfull, "There are not records. check datasource.");
        }
        public void FindContentUnitTest()
        {
            FindUnitTest(c => c.Live.Title == "LiveTitle1");
            Assert.IsTrue(_IsRecordOperationSuccesfull, "Record Exists but there is problem.");

            FindUnitTest(c => c.Live.Title == "sdfgfsfb");
            Assert.IsFalse(_IsRecordOperationSuccesfull, "Record doesn't exists. There is problem.");
        }
        public void AddContentUnitTest()
        {
            ContentType LiveContent1 = new ContentType()
            {
                Text = "LiveText2"
            };
            AddContentTester(new Content() {Live = LiveContent1 });
            Assert.IsTrue(_IsRecordOperationSuccesfull, "Not same text. There is problem");

            ContentType LiveContent2 = new ContentType()
            {
                Text = "LiveText1"
            };
            AddContentTester(new Content() { Live = LiveContent2 }) ;
            Assert.IsFalse(_IsRecordOperationSuccesfull, "Same text. There is problem");
        }
        public void AddContentTester(Content content)
        {
            IEnumerable<Content> contents = Repository.GetAll();
            _IsRecordOperationSuccesfull = contents.Where(x => x.Live.Text == content.Live.Text).Count() == 0;
        }
        public void AddRangeContentUnitTests()
        {
            List<Content> contents1 = new List<Content>();
            contents1.Add(new Content() { Live = new ContentType() { Text = "LiveText2" } });
            contents1.Add(new Content() { Live = new ContentType() { Text = "LiveText3" } });
            contents1.Add(new Content() { Live = new ContentType() { Text = "LiveText4" } });
            AddRangeContentTester(contents1);
            Assert.IsTrue(_IsRecordOperationSuccesfull, "Not same texts but something is wrong");

            List<Content> contents2 = new List<Content>();
            contents2.Add(new Content() { Live = new ContentType() { Text = "LiveText1" } });
            contents2.Add(new Content() { Live = new ContentType() { Text = "LiveText2" } });
            contents2.Add(new Content() { Live = new ContentType() { Text = "LiveText3" } });
            AddRangeContentTester(contents2);
            Assert.IsFalse(_IsRecordOperationSuccesfull, "There are some similar texts but there is problem");
        }
        public void AddRangeContentTester(IEnumerable<Content> contents)
        {
            IEnumerable<Content> contentsInDataBase = Repository.GetAll();
            _IsRecordOperationSuccesfull = contents.Where(x => contentsInDataBase.Any(y => y.Live.Text != x.Live.Text)).Count() == contents.Count();
        }
        public void RemoveContentUnitTests()
        {
            RemoveContentTester(new Content() { ID = 1, Live = new ContentType() { Title = "LiveTitle1" } });
            Assert.IsTrue(_IsRecordOperationSuccesfull, "There is record for delete but there is problem");

            RemoveContentTester(new Content() { ID = 2, Live = new ContentType() { Title = "LiveTitle2" } });
            Assert.IsFalse(_IsRecordOperationSuccesfull, "There isn,t record but somethig is wrong");
        }
        public void RemoveContentTester(Content content)
        {
            IEnumerable<Content> contents = Repository.GetAll();
            _IsRecordOperationSuccesfull = contents.Where(x => x.ID == content.ID).Count() > 0;
        }
        public void RemoveRangeContentUnitTests()
        {
            List<Content> contents1 = new List<Content>();
            contents1.Add(new Content() { ID = 1, Live = new ContentType() { Title = "LiveTitle1" } });
            RemoveRangeContentTester(contents1);
            Assert.IsTrue(_IsRecordOperationSuccesfull, "There is comments but somethig is wrong");

            List<Content> contents2 = new List<Content>();
            contents2.Add(new Content() { ID = 2, Live = new ContentType() { Title = "LiveTitle2" } });
            RemoveRangeContentTester(contents2);
            Assert.IsFalse(_IsRecordOperationSuccesfull, "There Are not elements Somethig is wrong");
        }
        public void RemoveRangeContentTester(IEnumerable<Content> contents)
        {
            IEnumerable<Content> contentsInDataBase = Repository.GetAll();
            _IsRecordOperationSuccesfull = contents.Where(x => contentsInDataBase.Any(y => y.ID == x.ID)).Count() > 0;
        }
    }
}
