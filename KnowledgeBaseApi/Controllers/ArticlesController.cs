using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KnowledgeBaseApi.Models;

namespace KnowledgeBaseApi.Controllers
{
    [Route("api/articles")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private readonly ArticleContext _context;

        public ArticlesController(ArticleContext context)
        {
            _context = context;

            if (_context.Articles.Count() == 0)
            {
                _context.Articles.Add(new Article {
                    Id = 1,
                    Title = "Article1",
                    Summary = "",
                    Url = "website.com/path",
                    Tags = new List<Tag> {
                        new Tag { Id = 1, Name = "aaa" },
                        new Tag { Id = 3, Name = "ccc" },
                        new Tag { Id = 5, Name = "eee" }
                    }
                });
                _context.SaveChanges();
            }
        }

        // GET: api/articles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Article>>> GetArticles()
        {
            return await _context.Articles.ToListAsync();
        }

        // GET: api/articles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Article>> GetArticle(long id)
        {
            var article = await _context.Articles.FindAsync(id);

            if (article == null)
            {
                return NotFound();
            }

            return article;
        }
    }
}