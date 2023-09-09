using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace csharpapp.Models;
public class TodoItem
{
    public int TodoItemId { get; set; }

    public required string Text { get; set; }

    public bool IsChecked { get; set; } = false;

    // public Todo todo { get; set; }
}