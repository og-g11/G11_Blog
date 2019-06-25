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
    public class CommentRepositoryUnitTesting : RepositoryUnitTesting<Comment>
    {
        internal override IRepository<Comment> Repository => _unitOfWork.CommentRepository;

        [TestMethod]
        public void CommentTesting()
        {
            GetCommentUnitTests();
            GetAllCommentUnitTests();
            FindCommentUnitTests();
            AddCommentUnitTests();
            AddRangeCommentUnitTests();
            RemoveCommentUnitTests();
            RemoveRangeCommentUnitTests();
        }

        public void GetCommentUnitTests()
        {
            GetUnitTesting(1);
            Assert.IsTrue(_IsRecordOperationSuccesfull, "Correct id but somethig is wrong.");

            GetUnitTesting(2);
            Assert.IsFalse(_IsRecordOperationSuccesfull, "Not correct id. somethig is wrong.");
        }
        public void GetAllCommentUnitTests()
        {
            GetAllUnitTesting(true);
            Assert.IsTrue(_IsRecordOperationSuccesfull, "There are some records but somethis is wrong.");

            GetAllUnitTesting(false);
            Assert.IsFalse(_IsRecordOperationSuccesfull, "There are not records. check datasource.");
        }
        public void FindCommentUnitTests()
        {
            FindUnitTest(c => c.Text == "Comment1");
            Assert.IsTrue(_IsRecordOperationSuccesfull, "Record Exists but there is problem.");

            FindUnitTest(c => c.Text == "sdfgfsfb");
            Assert.IsFalse(_IsRecordOperationSuccesfull, "Record doesn't exists. There is problem.");
        }
        public void AddCommentUnitTests()
        {
            AddCommentTester(new Comment() { ID = 2 });
            Assert.IsTrue(_IsRecordOperationSuccesfull, "Not same id. There is problem");

            AddCommentTester(new Comment() { ID = 1 });
            Assert.IsFalse(_IsRecordOperationSuccesfull, "Same id. There is problem");
        }
        public void AddCommentTester(Comment comment)
        {
            IEnumerable<Comment> comments = Repository.GetAll();
            _IsRecordOperationSuccesfull = comments.Where(x => x.ID == comment.ID).Count() == 0;
        }
        public void AddRangeCommentUnitTests()
        {
            List<Comment> comments1 = new List<Comment>();
            comments1.Add(new Comment() { ID = 2, Text = "123" });
            comments1.Add(new Comment() { ID = 3, Text = "123" });
            comments1.Add(new Comment() { ID = 4, Text = "123" });
            AddRangeCommentTester(comments1);
            Assert.IsTrue(_IsRecordOperationSuccesfull, "Not same ids but something is wrong");

            List<Comment> comments2 = new List<Comment>();
            comments2.Add(new Comment() { ID = 1, Text = "123" });
            comments2.Add(new Comment() { ID = 2, Text = "123" });
            comments2.Add(new Comment() { ID = 3, Text = "123" });
            AddRangeCommentTester(comments2);
            Assert.IsFalse(_IsRecordOperationSuccesfull, "There are some similar ids but there is problem");
        }
        public void AddRangeCommentTester(IEnumerable<Comment> comments)
        {
            IEnumerable<Comment> commentsInDataBase = Repository.GetAll();
            _IsRecordOperationSuccesfull = comments.Where(x => commentsInDataBase.Any(y => y.ID != x.ID)).Count() == comments.Count();
        }
        public void RemoveCommentUnitTests()
        {
            RemoveCommentTester(new Comment() { ID = 1, Text = "Comment1" });
            Assert.IsTrue(_IsRecordOperationSuccesfull, "There is record for delete but there is problem");

            RemoveCommentTester(new Comment() { ID = 2, Text = "Comment2" });
            Assert.IsFalse(_IsRecordOperationSuccesfull, "There isn,t record but somethig is wrong");
        }
        public void RemoveCommentTester(Comment comment)
        {
            IEnumerable<Comment> comments = Repository.GetAll();
            _IsRecordOperationSuccesfull = comments.Where(x => x.ID == comment.ID).Count() > 0;
        }
        public void RemoveRangeCommentUnitTests()
        {
            List<Comment> comments1 = new List<Comment>();
            comments1.Add(new Comment() { ID = 1, Text = "Comment1" });
            RemoveRangeCommentTester(comments1);
            Assert.IsTrue(_IsRecordOperationSuccesfull, "There is comments but somethig is wrong");

            List<Comment> comments2 = new List<Comment>();
            comments2.Add(new Comment() { ID = 2, Text = "Comment2" });
            RemoveRangeCommentTester(comments2);
            Assert.IsFalse(_IsRecordOperationSuccesfull, "There Are not elements Somethig is wrong");
        }
        public void RemoveRangeCommentTester(IEnumerable<Comment> comments)
        {
            IEnumerable<Comment> commentsInDataBase = Repository.GetAll();
            _IsRecordOperationSuccesfull = comments.Where(x => commentsInDataBase.Any(y => y.ID == x.ID)).Count() > 0;
        }
    }
}
