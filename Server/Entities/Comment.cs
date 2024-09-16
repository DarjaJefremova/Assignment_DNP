namespace Entities;

public class Comment
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int PostId { get; set; }
    public string Content { get; set; }
    
    public Comment(int userId, int postId, string content)
    {
        UserId = userId;
        PostId = postId;
        Content = content;
    }
}