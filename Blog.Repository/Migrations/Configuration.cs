namespace Blog.Repository.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using Blog.Domain;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Blog.Repository.BlogDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Blog.Repository.BlogDBContext context)
        {
            UnitOfWork unitOfWork = new UnitOfWork();
            User user = new User()
            {
                FirstName = "Jack",
                LastName = "Anderson",
                Email = "J@J.mail.com",
                Password = "password",
                IsDeleted = false,
                DateCreated = DateTime.Now,
                Salt = "123"
            };
            Category category = new Category() { Name = "Category1", Description = "Category1", IsDeleted = false };
            Comment comment = new Comment()
            {
                Text = "Comment1",
                Creator = user,
                DateCreated = DateTime.Now,
                IsDeleted = false,
            };

            Content content = new Content()
            {
                Live = new ContentType() { Title = "LiveTitle1", Summary = "LiveSummary1", Text = "LiveText1" },
                Draft = new ContentType() { Title = "DraftTitle1", Summary = "DraftSummary1", Text = "DraftText1" },
                DateCreated = DateTime.Now,
                Category = category,
                Creator = user,
                IsDeleted = false,
                IsPublic = true,
                Comments = unitOfWork.CommentRepository.Find(x => x.ID == 1).ToList(),
            };
            Photo photo = new Photo() { OriginalFileName = "Photo1", Content = content };

            unitOfWork.UserRepository.Add(user);
            unitOfWork.CategotyRepository.Add(category);
            unitOfWork.CommentRepository.Add(comment);
            unitOfWork.PhotoRepository.Add(photo);
            unitOfWork.ContentRepository.Add(content);
            unitOfWork.SaveChanges();
        }
    }
}
