using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Blog.Domain;
namespace Blog.Repository
{
    public class BlogDBContext : DbContext
    {
       public BlogDBContext()
       {
            Database.CreateIfNotExists();
       }
       
        public DbSet<Content> Contents {get; set;}
        public DbSet<Category> Categoties {get; set;}
        public DbSet<User> Users {get; set;}
        public DbSet<Comment> Comments {get; set;}

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }
}
