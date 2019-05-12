using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Domain;
using Blog.Repository;

namespace Blog.Service {
    public class AddCategory {
        public AddCategory() {
        }
        public AddCategory(int id, string name, string description, bool isDeleted) {
            var myCategory = new Category();
            myCategory.ID = id;
            myCategory.Name = name;
            myCategory.Description = description;
            myCategory.IsDeleted = false;

            using (BlogDBContext myBlogDBContext = new BlogDBContext()) {
                myBlogDBContext.Categoties.Add(myCategory);
                myBlogDBContext.SaveChanges();
            }
        }
        public void ReadCategory() {
            using (BlogDBContext myBlogDBContext = new BlogDBContext()) {
                var readCategory = from Category in myBlogDBContext.Categoties
                                   select Category;

                foreach (var x in readCategory) {
                    int id = x.ID;
                    string name = x.Name;
                    string description = x.Description;
                }
            }
        }    
    }
}
