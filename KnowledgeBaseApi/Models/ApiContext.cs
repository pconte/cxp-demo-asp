using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace KnowledgeBaseApi.Models
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options)
            : base(options)
        {
            
        }

        public DbSet<Article> Articles { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Suggestion> Suggestions { get; set; }

        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //     optionsBuilder.UseSqlite("Data Source=KnowledgeBase.db");
        // }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ArticleTag>()
                .HasKey(at => new { at.ArticleId, at.TagId });

            modelBuilder.Entity<ArticleTag>() 
                .HasOne(at => at.Article)
                .WithMany(a => a.Tags)
                .HasForeignKey(at => at.ArticleId);
 
            modelBuilder.Entity<ArticleTag>() 
                .HasOne(at => at.Tag) 
                .WithMany(t => t.Articles)
                .HasForeignKey(at => at.TagId);

            SeedData(modelBuilder);
        }

        protected static void SeedData(ModelBuilder modelBuilder)
        {
            // Tags

            modelBuilder.Entity<Tag>().HasData(new Tag
            {
                TagId = 1,
                Name = "Tag1",
                IsSelected = false,
                IsInitSelected = false
            });
            modelBuilder.Entity<Tag>().HasData(new Tag
            {
                TagId = 2,
                Name = "Tag2",
                IsSelected = false,
                IsInitSelected = false
            });
            modelBuilder.Entity<Tag>().HasData(new Tag
            {
                TagId = 3,
                Name = "Tag3",
                IsSelected = false,
                IsInitSelected = false
            });
            modelBuilder.Entity<Tag>().HasData(new Tag
            {
                TagId = 4,
                Name = "Tag4",
                IsSelected = false,
                IsInitSelected = false
            });
            modelBuilder.Entity<Tag>().HasData(new Tag
            {
                TagId = 5,
                Name = "Tag5",
                IsSelected = false,
                IsInitSelected = false
            });

            // Articles

            modelBuilder.Entity<Article>().HasData(new Article
            {
                ArticleId = 1,
                Title = "Article1",
                Summary = "",
                Url = "website.com/path"
            });

            modelBuilder.Entity<Article>().HasData(new Article
            {
                ArticleId = 2,
                Title = "Article2",
                Summary = "",
                Url = "website.com/path"
            });

            // ArticlesTags

            modelBuilder.Entity<ArticleTag>().HasData(new ArticleTag
            {
                ArticleId = 1,
                TagId = 1
            });
            modelBuilder.Entity<ArticleTag>().HasData(new ArticleTag
            {
                ArticleId = 1,
                TagId = 3
            });
            modelBuilder.Entity<ArticleTag>().HasData(new ArticleTag
            {
                ArticleId = 1,
                TagId = 5
            });
            modelBuilder.Entity<ArticleTag>().HasData(new ArticleTag
            {
                ArticleId = 2,
                TagId = 2
            });
            modelBuilder.Entity<ArticleTag>().HasData(new ArticleTag
            {
                ArticleId = 2,
                TagId = 4
            });
        }
    }
}