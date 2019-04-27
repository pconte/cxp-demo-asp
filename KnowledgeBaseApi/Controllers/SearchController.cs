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
        private readonly ApiContext _context;

        public SearchController(ApiContext context)
        {
            _context = context;
        }

        // POST: api/search
        [HttpPost]
        public async Task<ActionResult<IEnumerable<Article>>> PostSearch(string searchString)
        {
            // _context.Suggestions.Add(new Suggestion {
            //     SearchString = searchString,
            //     Count = 1
            // });
            // _context.SaveChanges();

            return await _context.Articles.ToListAsync();
        }
    }
}