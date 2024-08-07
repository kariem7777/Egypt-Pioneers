using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Library library = new Library();
        Librarian librarian = new Librarian(1, "kareem");

        librarian.AddBook(library, new Book("poor dad, rich dad", "Robert", 5));
        librarian.AddBook(library, new Book("david Copperfiled", "jinefer", 8));


        librarian.DisplayAllBooks(library);

        Member m1 = new Member(1, "kareem");
        Member m2 = new Member(2, "mohammed");

        librarian.RegisterMember(library, m1);
        librarian.RegisterMember(library, m2);

        librarian.DisplayAllMembers(library);

        m1.BorrowBook(library, "poor dad, rich dad");
        m2.BorrowBook(library, "poor dad, rich dad");

        m1.ReturnBook(library, "poor dad, rich dad");

        librarian.DisplayAllBooks(library);
    }
}

public class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int NumberOfCopies { get; set; }

    public Book(string title, string author, int numberOfCopies)
    {
        Title = title;
        Author = author;
        NumberOfCopies = numberOfCopies;
    }
}

public class Member
{
    public int MemberID { get; set; }
    public string Name { get; set; }

    public Member(int memberID, string name)
    {
        MemberID = memberID;
        Name = name;
    }

    public void BorrowBook(Library lib, string bookTitle)
    {
        var book = lib.books.Find(b => b.Title == bookTitle);
        if (book != null && book.NumberOfCopies > 0)
        {
            book.NumberOfCopies--;
            Console.WriteLine($"Member {MemberID} borrowed \"{book.Title}\".");
        }
        else
        {
            Console.WriteLine($"The book \"{bookTitle}\" is not available.");
        }
    }

    public void ReturnBook(Library lib, string bookTitle)
    {
        var book = lib.books.Find(b => b.Title == bookTitle);
        if (book != null)
        {
            book.NumberOfCopies++;
            Console.WriteLine($"Member {MemberID} returned \"{book.Title}\".");
        }
        else
        {
            Console.WriteLine($"The book \"{bookTitle}\" does not exist in the library.");
        }
    }
}

public class Librarian
{
    public int EmployeeID { get; set; }
    public string Name { get; set; }

    public Librarian(int employeeID, string name)
    {
        EmployeeID = employeeID;
        Name = name;
    }
    public void AddBook(Library lib, Book book)
    {
        lib.books.Add(book);
    }

    public void RemoveBook(Library lib, string title)
    {
        lib.books.RemoveAll(b => b.Title == title);
    }

    public void DisplayAllBooks(Library lib)
    {
        Console.WriteLine("Books in the Library:");
        foreach (var book in lib.books)
        {
            Console.WriteLine($"Title: {book.Title}, Author: {book.Author}, Copies: {book.NumberOfCopies}");
        }
    }

    public void RegisterMember(Library lib, Member member)
    {
        lib.members.Add(member);
    }

    public void DisplayAllMembers(Library lib)
    {
        Console.WriteLine("Members in the Library:");
        foreach (var member in lib.members)
        {
            Console.WriteLine($"MemberID: {member.MemberID}, Name: {member.Name}");
        }
    }
}

public class Library
{
    public List<Book> books;
    public List<Member> members;

    public Library()
    {
        books = new List<Book>();
        members = new List<Member>();
    }
}