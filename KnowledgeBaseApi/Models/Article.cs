using System;
namespace KnowledgeBaseApi.Models
{
    public class Article
    {
        public Article()
        {
        }

        public long Id { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string Summary { get; set; }
        public int[] TagIds { get; set; }
    }
}
