using System;
using System.Collections.Generic;

//Enhance this code by implementing the suggested features. 
//    Add methods like ReserveBook, CheckOutBook, and 
//    DisplayTransactionHistory in the Library and User classes to
//    fulfill the requirements.

public class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public bool IsReserved { get; set; }

    // Additional properties and methods...
}

public class Library
{
    private List<Book> books = new List<Book>();

    public void AddBook(Book book)
    {
        books.Add(book);
    }

    public void DisplayBookList()
    {
        foreach (var book in books)
        {
            Console.WriteLine($"Title: {book.Title}, Author: {book.Author}, Reserved: {book.IsReserved}");
        }
    }

    // Implement ReserveBook and other methods...
}

public class User
{
    public string Username { get; set; }
    public string Email { get; set; }
    public DateTime DateJoined { get; set; }
    public string Role { get; set; }
    public List<Transaction> Transactions { get; set; } = new List<Transaction>();

    // Additional properties and methods...
}

public class Transaction
{
    public string TransactionType { get; set; }
    public string BookTitle { get; set; }
    public DateTime TransactionDate { get; set; }

    // Additional properties and methods...
}

class Program
{
    static void Main()
    {
        // Sample usage of the Library Management System
        Library library = new Library();

        Book book1 = new Book { Title = "The Catcher in the Rye", Author = "J.D. Salinger" };
        Book book2 = new Book { Title = "To Kill a Mockingbird", Author = "Harper Lee" };

        library.AddBook(book1);
        library.AddBook(book2);

        library.DisplayBookList();
        // Implement book reservations, user roles, and transactions...
    }
}
