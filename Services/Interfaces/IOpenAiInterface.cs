using MondayFunday.Models;

namespace MondayFunday.Services.Interfaces
{
    public interface IOpenAiInterface
    {
        Task<ChatResponse> Chat(string message);
    }
}
