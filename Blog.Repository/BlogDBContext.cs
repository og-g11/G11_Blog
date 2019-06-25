using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Blog.Domain;
using System.Data.Entity.Infrastructure.Annotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Repository {
	internal class BlogDBContext : DbContext {
		public BlogDBContext() {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<BlogDBContext, Migrations.Configuration>());
        }

		public virtual DbSet<User> Users { get; set; }
		public virtual DbSet<Category> Categoties { get; set; }
		public virtual DbSet<Content> Contents { get; set; }
		public virtual DbSet<Photo> Photos { get; set; }
		public virtual DbSet<Comment> Comments { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder) {
			base.OnModelCreating(modelBuilder);
			modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

			modelBuilder
				.Entity<User>()
				.HasIndex(x => x.Email)
				.IsUnique();

			//modelBuilder
			//	.Entity<User>()
			//	.Property(t => t.Email)
			//	.HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("IX_Email") { IsUnique = true }));
		}
	}
}
