using System;
using System.Collections.Generic;

public class User
{
    private string username;
    private string email;
    private DateTime dateJoined;

    public User(string username, string email)
    {
        this.username = username;
        this.email = email;
        this.dateJoined = DateTime.Now;
    }

    public string GetUsername() => username;
    public string GetEmail() => email;
    public DateTime GetDateJoined() => dateJoined;

    public virtual void DisplayUserProfile()
    {
        Console.WriteLine($"Username: {GetUsername()}");
        Console.WriteLine($"Email: {GetEmail()}");
        Console.WriteLine($"Joined on: {GetDateJoined()}");
        Console.WriteLine();
    }
}

public class AdminUser : User
{
    public AdminUser(string username, string email) : base(username, email) { }

    public void GrantAdminPrivileges()
    {
        // Implement admin-specific privileges
        Console.WriteLine("Admin privileges granted.");
    }

    public override void DisplayUserProfile()
    {
        base.DisplayUserProfile();
        Console.WriteLine("Admin User Profile");
    }
}

public class RegularUser : User
{
    public RegularUser(string username, string email) : base(username, email) { }

    public void LikePost(Post post)
    {
        // Implement like functionality
        Console.WriteLine($"{GetUsername()} liked a post.");
    }

    public override void DisplayUserProfile()
    {
        base.DisplayUserProfile();
        Console.WriteLine("Regular User Profile");
    }
}

public interface ILikeable
{
    void Like();
}

public abstract class Content : ILikeable
{
    private string content;
    private User author;
    private int likes;

    public Content(string content, User author)
    {
        this.content = content;
        this.author = author;
        this.likes = 0;
    }

    public string GetContent() => content;
    public User GetAuthor() => author;

    public void Like()
    {
        likes++;
        Console.WriteLine($"{author.GetUsername()} liked this content.");
    }

    public virtual void Display()
    {
        Console.WriteLine($"Author: {GetAuthor().GetUsername()}");
        Console.WriteLine($"Content: {GetContent()}");
        Console.WriteLine($"Likes: {likes}");
    }
}

public class Post : Content
{
    private List<Comment> comments = new List<Comment>();

    public Post(string content, User author) : base(content, author) { }

    public void AddComment(Comment comment)
    {
        comments.Add(comment);
    }

    public override void Display()
    {
        base.Display();
        Console.WriteLine("Comments:");
        foreach (var comment in comments)
        {
            comment.Display();
        }
        Console.WriteLine();
    }
}

public class Comment : Content
{
    public Comment(string content, User author) : base(content, author) { }

    public override void Display()
    {
        base.Display();
        Console.WriteLine();
    }
}

class Program
{
    static void Main()
    {
        // Example usage
        User user1 = new AdminUser("AdminUser", "admin@example.com");
        User user2 = new RegularUser("RegularUser", "user@example.com");

        user1.DisplayUserProfile();
        user2.DisplayUserProfile();

        Post post1 = new Post("This is my first post!", user1);
        Comment comment1 = new Comment("Great post!", user2);
        post1.AddComment(comment1);

        post1.Display();

        // User-specific actions
        ((RegularUser)user2).LikePost(post1);
        ((AdminUser)user1).GrantAdminPrivileges();
    }
}
