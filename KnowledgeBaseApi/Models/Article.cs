using System;
using System.Collections.Generic;

namespace KnowledgeBaseApi.Models
{
    public class Article
    {
        public Article()
        {
        }

        public long ArticleId { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string Summary { get; set; }
        public List<ArticleTag> Tags { get; set; }
    }
}
