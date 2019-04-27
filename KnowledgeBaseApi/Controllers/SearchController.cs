using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KnowledgeBaseApi.Models;

namespace KnowledgeBaseApi.Controllers
{
    [Route("api/search")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly ArticleContext _articleContext;
        private readonly SuggestionContext _suggestionContext;

        public SearchController(ArticleContext articleContext, SuggestionContext suggestionContext)
        {
            _articleContext = articleContext;
            _suggestionContext = suggestionContext;

            if (_articleContext.Articles.Count() == 0)
            {
                _articleContext.Articles.Add(new Article {
                    Id = 1,
                    Title = "Article1",
                    Summary = "",
                    Url = "website.com/path",
                    Tags = new List<Tag>() {
                        new Tag() { Id = 1, Name = "aaa" },
                        new Tag() { Id = 3, Name = "ccc" },
                        new Tag() { Id = 5, Name = "eee" }
                    }
                });
                _articleContext.SaveChanges();
            }
        }

        // POST: api/search
        [HttpPost]
        public async Task<ActionResult<IEnumerable<Article>>> PostSearch(string searchString)
        {
            // _suggestionContext.Suggestions.Add(new Suggestion {
            //     SearchString = searchString,
            //     Count = 1
            // });
            // _suggestionContext.SaveChanges();

            return await _articleContext.Articles.ToListAsync();
        }
    }
}