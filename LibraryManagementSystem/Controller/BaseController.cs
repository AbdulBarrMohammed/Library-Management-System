using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Spectre.Console;

namespace LibraryManagementSystem.Controller
{
    internal abstract class BaseController
{
    protected void DisplayMessage(string message, string color = "yellow")
    {
        AnsiConsole.MarkupLine($"[{color}]{message}[/]");
    }

    protected bool ConfirmDeletion(string itemName)
    {
        var confirm = AnsiConsole.Confirm($"Are you sure you want to delete [red]{itemName}[/]?");

        return confirm;
    }
}
}
