using System.Net.Http.Json;
using MondayFunday.Models;
using MondayFunday.Services.Interfaces;

namespace MondayFunday.Services.ExternalApiService
{
    public class ExternalApiServiceCRUD : IExternalApiInterface
    {
        private readonly HttpClient _httpClient;

        public ExternalApiServiceCRUD(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // GET all todos from JSONPlaceholder
        public async Task<List<TodoItem>> GetTodos()
        {
            var todos = await _httpClient.GetFromJsonAsync<List<TodoItem>>("todos");
            return todos ?? new List<TodoItem>();
        }

        // GET a single todo by ID
        public async Task<TodoItem?> GetTodoById(int id)
        {
            var todo = await _httpClient.GetFromJsonAsync<TodoItem>($"todos/{id}");
            return todo;
        }

        // GET all posts
        public async Task<List<Post>> GetPosts()
        {
            var posts = await _httpClient.GetFromJsonAsync<List<Post>>("posts");
            return posts ?? new List<Post>();
        }

        // POST - create a new post (JSONPlaceholder fakes the creation and returns it)
        public async Task<Post?> CreatePost(Post post)
        {
            var response = await _httpClient.PostAsJsonAsync("posts", post);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Post>();
        }
    }
}
