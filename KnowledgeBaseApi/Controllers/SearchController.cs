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
        private readonly ArticleContext _context;

        public SearchController(ArticleContext context)
        {
            _context = context;

            if (_context.Articles.Count() == 0)
            {
                _context.Articles.Add(new Article { Name = "Article1" });
                _context.SaveChanges();
            }
        }

        // POST: api/search
        [HttpPost]
        public async Task<ActionResult<IEnumerable<Article>>> PostSearch()
        {
            return await _context.Articles.ToListAsync();
        }
    }
}