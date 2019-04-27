using System;
using System.Collections.Generic;

namespace KnowledgeBaseApi.Models
{
    public class ArticleTag
    {
        public ArticleTag()
        {
        }
    
        public long ArticleId { get; set; }
        public Article Article { get; set; }
        public long TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
