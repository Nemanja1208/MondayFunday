using MondayFunday.Models;

namespace MondayFunday.Services.Interfaces
{
    public interface IExternalApiInterface
    {
        Task<List<TodoItem>> GetTodos();
        Task<TodoItem?> GetTodoById(int id);
        Task<List<Post>> GetPosts();
        Task<Post?> CreatePost(Post post);
    }
}
