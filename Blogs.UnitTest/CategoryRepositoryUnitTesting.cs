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
    public class CategoryRepositoryUnitTesting : RepositoryUnitTesting<Category>
    {
        internal override IRepository<Category> Repository => _unitOfWork.CategotyRepository;
        [TestMethod]
        public void CategoryTesting()
        {
            GetCategoryUnitTests();
            GetAllCategoryUnitTests();
            FindCategoryUnitTests();
            AddCategoryUnitTests();
            AddRangeCategoryUnitTests();
            RemoveCategoryUnitTests();
            RemoveRangeCategoryUnitTests();
        }

        public void GetCategoryUnitTests()
        {
            GetUnitTesting(1);
            Assert.IsTrue(_IsRecordOperationSuccesfull, "Correct id but somethig is wrong.");

            GetUnitTesting(2);
            Assert.IsFalse(_IsRecordOperationSuccesfull, "Not correct id. somethig is wrong.");
        }
        public void GetAllCategoryUnitTests()
        {
            GetAllUnitTesting(true);
            Assert.IsTrue(_IsRecordOperationSuccesfull, "There are some records but somethis is wrong.");

            GetAllUnitTesting(false);
            Assert.IsFalse(_IsRecordOperationSuccesfull, "There are not records. check datasource.");
        }
        public void FindCategoryUnitTests()
        {
            FindUnitTest(c => c.Name == "Category1");
            Assert.IsTrue(_IsRecordOperationSuccesfull, "Record Exists but there is problem.");

            FindUnitTest(c => c.Description == "Category1");
            Assert.IsTrue(_IsRecordOperationSuccesfull, "Record Exists but there is problem.");

            FindUnitTest(c => c.Name == "sdfgfsfb");
            Assert.IsFalse(_IsRecordOperationSuccesfull, "Record doesn't exists. There is problem.");

            FindUnitTest(c => c.Description == "sdfgfsfb");
            Assert.IsFalse(_IsRecordOperationSuccesfull, "Record doesn't exists. There is problem.");
        }
        public void AddCategoryUnitTests()
        {
            AddCategoryTester(new Category() { Name = "Category2", Description = "Category1" });
            Assert.IsTrue(_IsRecordOperationSuccesfull, "Not same name. There is problem");

            AddCategoryTester(new Category() { Name = "Category1", Description = "Category2" });
            Assert.IsFalse(_IsRecordOperationSuccesfull, "Same name. There is problem");
        }
        public void AddCategoryTester(Category category)
        {
            IEnumerable<Category> categories = Repository.GetAll();
            _IsRecordOperationSuccesfull = categories.Where(x => x.Name == category.Name).Count() == 0;
        }
        public void AddRangeCategoryUnitTests()
        {
            List<Category> categories1 = new List<Category>();
            categories1.Add(new Category() { Name = "Category2", Description = "Category2" });
            categories1.Add(new Category() { Name = "Category3", Description = "Category3" });
            categories1.Add(new Category() { Name = "Category4", Description = "Category4" });
            AddRangeCategotyTester(categories1);
            Assert.IsTrue(_IsRecordOperationSuccesfull, "Not same names but something is wrong");

            List<Category> categories2 = new List<Category>();
            categories1.Add(new Category() { Name = "Category1", Description = "Category1" });
            categories1.Add(new Category() { Name = "Category2", Description = "Category2" });
            categories1.Add(new Category() { Name = "Category3", Description = "Category3" });
            AddRangeCategotyTester(categories1);
            Assert.IsFalse(_IsRecordOperationSuccesfull, "There are some similar names but there is problem");
        }
        public void AddRangeCategotyTester(IEnumerable<Category> categories)
        {
            IEnumerable<Category> categoriesInDataBase = Repository.GetAll();
            _IsRecordOperationSuccesfull = categories.Where(x => categoriesInDataBase.Any(y => y.Name != x.Name)).Count() == categories.Count();
        }
        public void RemoveCategoryUnitTests()
        {
            RemoveCategoryTester(new Category() { ID = 1, Name = "Category1", Description = "Category1" });
            Assert.IsTrue(_IsRecordOperationSuccesfull, "There is record for delete but there is problem");

            RemoveCategoryTester(new Category() { ID = 2, Name = "Category2", Description = "Category2" });
            Assert.IsFalse(_IsRecordOperationSuccesfull, "There isn,t record but somethig is wrong");
        }
        public void RemoveCategoryTester(Category category)
        {
            IEnumerable<Category> categories = Repository.GetAll();
            _IsRecordOperationSuccesfull = categories.Where(x => x.ID == category.ID).Count() > 0;
        }
        public void RemoveRangeCategoryUnitTests()
        {
            List<Category> categories1 = new List<Category>();
            categories1.Add(new Category() { ID = 1, Name = "Category1", Description = "Category1" });
            RemoveRangeCategoryTester(categories1);
            Assert.IsTrue(_IsRecordOperationSuccesfull, "There is categories but somethig is wrong");

            List<Category> categories2 = new List<Category>();
            categories1.Add(new Category() { ID = 2, Name = "Category1", Description = "Category1" });
            RemoveRangeCategoryTester(categories2);
            Assert.IsFalse(_IsRecordOperationSuccesfull, "There Are not elements Somethig is wrong");
        }
        public void RemoveRangeCategoryTester(IEnumerable<Category> categories)
        {
            IEnumerable<Category> categoriesInDataBase = Repository.GetAll();
            _IsRecordOperationSuccesfull = categories.Where(x => categoriesInDataBase.Any(y => y.ID == x.ID)).Count() > 0;
        }
    }
}
