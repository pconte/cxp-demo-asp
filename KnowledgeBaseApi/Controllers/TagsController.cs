using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KnowledgeBaseApi.Models;

namespace KnowledgeBaseApi.Controllers
{
    [Route("api/tags")]
    [ApiController]
    public class TagsController : ControllerBase
    {
        private readonly TagContext _context;

        public TagsController(TagContext context)
        {
            _context = context;

            if (_context.Tags.Count() == 0)
            {
                _context.Tags.Add(new Tag {
                    Id = 1,
                    Name = "Tag1",
                    IsSelected = false,
                    IsInitSelected = false
                });
                _context.Tags.Add(new Tag {
                    Id = 2,
                    Name = "Tag2",
                    IsSelected = false,
                    IsInitSelected = false
                });
                _context.Tags.Add(new Tag {
                    Id = 3,
                    Name = "Tag3",
                    IsSelected = false,
                    IsInitSelected = false
                });
                _context.Tags.Add(new Tag {
                    Id = 4,
                    Name = "Tag4",
                    IsSelected = false,
                    IsInitSelected = false
                });
                _context.Tags.Add(new Tag {
                    Id = 5,
                    Name = "Tag5",
                    IsSelected = false,
                    IsInitSelected = false
                });
                _context.SaveChanges();
            }
        }

        // GET: api/tags
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tag>>> GetTags()
        {
            return await _context.Tags.ToListAsync();
        }

        // GET: api/tags/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tag>> GetTag(long id)
        {
            var tag = await _context.Tags.FindAsync(id);

            if (tag == null)
            {
                return NotFound();
            }

            return tag;
        }
    }
}