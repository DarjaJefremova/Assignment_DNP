using InMemoryRepositories;
using RepositoryContracts;
using Entities;

namespace CLI.UI;

public class CliApp
{
  private readonly IUserRepository userRepository;
  private readonly ICommentRepository commentRepository;
  private readonly IPostRepository postRepository;
  
  public CliApp(IUserRepository userRepository, ICommentRepository commentRepository, IPostRepository postRepository)
  {
    this.postRepository = postRepository;
    this.userRepository = userRepository;
    this.commentRepository = commentRepository;
  }
  
  public async Task StartAsync()
  {
    Console.WriteLine("Welcome to the CLI app!");
    Console.WriteLine("Available commands:");
    Console.WriteLine("1) Add a new user");
    Console.WriteLine("2) Add a new post");
    Console.WriteLine("3) Add a new comment");
    Console.WriteLine("4) List all users");
    Console.WriteLine("5) List all posts");
    Console.WriteLine("6) List all comments");
    Console.WriteLine("7) Exit the application");    
    
    string command = string.Empty;
    while (command != "exit")
    {
      Console.Write("> ");
      command = Console.ReadLine();
      switch (command)
      {
        case "1":
          await AddUserAsync();
          break;
        case "2":
          await AddPostAsync();
          break;
        case "3":
          await AddCommentAsync();
          break;
        case "4":
          ListUsers();
          break;
        case "5":
          ListPosts();
          break;
        case "6":
          ListComments();
          break;
        case "7":
          Console.WriteLine("Goodbye!");
          break;
        default:
          Console.WriteLine("Unknown command. Type 'help' to see the available commands.");
          break;
      }
    }
  }
  
  private async Task AddUserAsync()
  {
    Console.Write("Enter user name: ");
    string name = Console.ReadLine();
    Console.Write("Enter user password: ");
    string password = Console.ReadLine();
    User user = new User(name, password);
    await userRepository.AddAsync(user);
    Console.WriteLine("User added successfully.");
  }
  
  private async Task AddPostAsync()
  {
    Console.Write("Enter post title: ");
    string title = Console.ReadLine();
    Console.Write("Enter post content: ");
    string content = Console.ReadLine();
    Console.Write("Enter user id: ");
    int userId = int.Parse(Console.ReadLine());
    Post post = new Post(title, content, userId);
    await postRepository.AddAsync(post);
    Console.WriteLine("Post added successfully.");
  }
  
  private async Task AddCommentAsync()
  {
    Console.Write("Enter comment content: ");
    string content = Console.ReadLine();
    Console.Write("Enter user id: ");
    int userId = int.Parse(Console.ReadLine());
    Console.Write("Enter post id: ");
    int postId = int.Parse(Console.ReadLine());
    Comment comment = new Comment(userId, postId, content);
    await commentRepository.AddAsync(comment);
    Console.WriteLine("Comment added successfully.");
  }
  
  private void ListUsers()
  {
    var users = userRepository.GetMany().ToList();
    if (users.Any())
    {
      Console.WriteLine("Users:");
      foreach (var user in users)
      {
        Console.WriteLine($"- {user.Username}");
      }
    }
    else
    {
      Console.WriteLine("No users found.");
    }
  }
  
  private void ListPosts()
  {
    var posts = postRepository.GetMany().ToList();
    if (posts.Any())
    {
      Console.WriteLine("Posts:");
      foreach (var post in posts)
      {
        Console.WriteLine($"- {post.Title}");
      }
    }
    else
    {
      Console.WriteLine("No posts found.");
    }
  }
  
  private void ListComments()
  {
    var comments = commentRepository.GetMany().ToList();
    if (comments.Any())
    {
      Console.WriteLine("Comments:");
      foreach (var comment in comments)
      {
        Console.WriteLine($"- {comment.Content}");
      }
    }
    else
    {
      Console.WriteLine("No comments found.");
    }
  }
}
