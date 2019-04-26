using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KnowledgeBaseApi.Models;

namespace KnowledgeBaseApi.Controllers
{
    [Route("api/suggestions")]
    [ApiController]
    public class SuggestionsController : ControllerBase
    {
        private readonly SuggestionContext _context;

        public SuggestionsController(SuggestionContext context)
        {
            _context = context;

            if (_context.Suggestions.Count() == 0)
            {
                _context.Suggestions.Add(new Suggestion { Name = "Suggestion1" });
                _context.SaveChanges();
            }
        }

        // GET: api/suggestions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Suggestion>>> GetSuggestions()
        {
            return await _context.Suggestions.ToListAsync();
        }

        // GET: api/suggestions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Suggestion>> GetSuggestion(long id)
        {
            var tag = await _context.Suggestions.FindAsync(id);

            if (tag == null)
            {
                return NotFound();
            }

            return tag;
        }
    }
}