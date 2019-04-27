using System;
using System.Collections.Generic;

namespace KnowledgeBaseApi.Models
{
    public class Tag
    {
        public Tag()
        {
        }

        public long TagId { get; set; }
        public string Name { get; set; }
        public bool IsSelected { get; set; } = false;
        public bool IsInitSelected { get; set; } = false;
        public List<ArticleTag> Articles { get; set; }
    }
}
