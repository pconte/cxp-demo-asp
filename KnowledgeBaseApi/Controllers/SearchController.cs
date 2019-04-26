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
                    Url = "website.com/path",
                    TagIds = new int[] { 1, 3, 5 }
                });
                _articleContext.SaveChanges();
            }
        }

        // POST: api/search
        [HttpPost]
        public async Task<ActionResult<IEnumerable<Article>>> PostSearch(string searchString)
        {
            // _suggestionContext.Suggestions.Add(new Suggestion { SearchString = searchString });
            // _suggestionContext.SaveChanges();

            return await _articleContext.Articles.ToListAsync();
        }
    }
}