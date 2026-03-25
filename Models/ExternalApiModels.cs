namespace MondayFunday.Models
{
    // Models for JSONPlaceholder API (https://jsonplaceholder.typicode.com)
    public class TodoItem
    {
        public int UserId { get; set; }
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public bool Completed { get; set; }
    }

    public class Post
    {
        public int UserId { get; set; }
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
    }

    // Models for OpenAI API
    public class ChatRequest
    {
        public string Message { get; set; } = string.Empty;
    }

    public class ChatResponse
    {
        public string Response { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public int TokensUsed { get; set; }
    }

    // OpenAI API DTOs (for serialization)
    public class OpenAiChatRequest
    {
        public string Model { get; set; } = "gpt-4o-mini";
        public List<OpenAiMessage> Messages { get; set; } = new();
    }

    public class OpenAiMessage
    {
        public string Role { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
    }

    public class OpenAiChatResponse
    {
        public List<OpenAiChoice>? Choices { get; set; }
        public OpenAiUsage? Usage { get; set; }
        public string? Model { get; set; }
    }

    public class OpenAiChoice
    {
        public OpenAiMessage? Message { get; set; }
    }

    public class OpenAiUsage
    {
        public int Total_tokens { get; set; }
    }
}
