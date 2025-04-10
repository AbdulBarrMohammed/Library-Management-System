﻿using Spectre.Console;


var menuChoices = new string[3] { "View Books", "Add Book", "Delete Book" };

var books = new List<string>()
{
    "The Great Gatsby", "To Kill a Mockingbird", "1984", "Pride and Prejudice", "The Catcher in the Rye", "The Hobbit", "Moby-Dick", "War and Peace", "The Odyssey", "The Lord of the Rings", "Jane Eyre", "Animal Farm", "Brave New World", "The Chronicles of Narnia", "The Diary of a Young Girl", "The Alchemist", "Wuthering Heights", "Fahrenheit 451", "Catch-22", "The Hitchhiker's Guide to the Galaxy"
};


while (true)
{
    var choice = AnsiConsole.Prompt(
            new SelectionPrompt<MenuOption>()
            .Title("What do you want to do next?")
            .AddChoices(Enum.GetValues<MenuOption>()));


    switch (choice)
    {
        case MenuOption.ViewBooks:
            ViewBooks();
            break;
        case MenuOption.AddBook:
            AddBook();
            break;
        case MenuOption.DeleteBook:
            DeleteBook();
            break;
    }
}

void ViewBooks()
{
    AnsiConsole.MarkupLine("[yellow]List of Books:[/]");

    foreach (var book in books)
    {
        AnsiConsole.MarkupLine($"- [cyan]{book}[/]");
    }

    AnsiConsole.MarkupLine("Press Any Key to Continue.");
    Console.ReadKey();
}


void AddBook()
{
/* Spectre's Ask<> method allows us to prompt a message to grab
            the user's input. We can pass the type we expect as an answer
            for validation. We're storing the answer in the 'title' variable*/
            var title = AnsiConsole.Ask<string>("Enter the [green]title[/] of the book to add:");

            // checking if the book already exists to avoid duplication.
            if (books.Contains(title))
            {
                AnsiConsole.MarkupLine("[red]This book already exists.[/]");
            }
            else
            {
                //if book doesn't exist, add to the list of books.
                books.Add(title);
                AnsiConsole.MarkupLine("[green]Book added successfully![/]");
            }

            AnsiConsole.MarkupLine("Press Any Key to Continue.");
            Console.ReadKey();
}


void DeleteBook()
{
        // checking if there are any books to delete and letting the user know
            if (books.Count == 0)
            {
                AnsiConsole.MarkupLine("[red]No books available to delete.[/]");
                Console.ReadKey();
                return;
            }

            /* showing a list of books and letting the user choose with arrows
            using SelectionPrompt, similarly to what we do with the menu */
            var bookToDelete = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .Title("Select a [red]book[/] to delete:")
                .AddChoices(books));

            /* Using the Remove method to delete a book. This method returns a boolean
            that we can use to present a message in case of success or failure.*/
            if (books.Remove(bookToDelete))
            {
                AnsiConsole.MarkupLine("[red]Book deleted successfully![/]");
            }
            else
            {
                AnsiConsole.MarkupLine("[red]Book not found.[/]");
            }

            AnsiConsole.MarkupLine("Press Any Key to Continue.");
            Console.ReadKey();
}


enum MenuOption
{
    ViewBooks,
    AddBook,
    DeleteBook
}
