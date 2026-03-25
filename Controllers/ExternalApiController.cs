using Microsoft.AspNetCore.Mvc;
using MondayFunday.Models;
using MondayFunday.Services.Interfaces;

namespace MondayFunday.Controllers
{
    [Route("api/external")]
    [ApiController]
    public class ExternalApiController : ControllerBase
    {
        private readonly IExternalApiInterface _externalApiService;

        public ExternalApiController(IExternalApiInterface externalApiService)
        {
            _externalApiService = externalApiService;
        }

        // GET: api/external/todos
        [HttpGet("todos")]
        public async Task<ActionResult<List<TodoItem>>> GetTodos()
        {
            var todos = await _externalApiService.GetTodos();
            return Ok(todos);
        }

        // GET: api/external/todos/5
        [HttpGet("todos/{id}")]
        public async Task<ActionResult<TodoItem>> GetTodoById(int id)
        {
            var todo = await _externalApiService.GetTodoById(id);
            if (todo == null)
                return NotFound();

            return Ok(todo);
        }

        // GET: api/external/posts
        [HttpGet("posts")]
        public async Task<ActionResult<List<Post>>> GetPosts()
        {
            var posts = await _externalApiService.GetPosts();
            return Ok(posts);
        }

        // POST: api/external/posts
        [HttpPost("posts")]
        public async Task<ActionResult<Post>> CreatePost([FromBody] Post post)
        {
            var created = await _externalApiService.CreatePost(post);
            return Ok(created);
        }
    }
}
