﻿using Microsoft.EntityFrameworkCore;

namespace KnowledgeBaseApi.Models
{
    public class ArticleContext : DbContext
    {
        public ArticleContext(DbContextOptions<ArticleContext> options)
            : base(options)
        {
        }

        public DbSet<Article> Articles { get; set; }
    }
}