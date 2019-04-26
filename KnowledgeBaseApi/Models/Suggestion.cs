using System;
namespace KnowledgeBaseApi.Models
{
    public class Suggestion
    {
        public Suggestion()
        {
        }

        public long Id { get; set; }
        public string SearchString { get; set; }
        public int Count { get; set; }
    }
}
