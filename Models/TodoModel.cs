
namespace csharpapp.Models;
public class Todo
{
    public int TodoId { get; set; }
    public required string Name { get; set; }

    public List<TodoItem> TodoItems { get; set; } = new();

    public void AddTodoItem(TodoItem item)
    {
        TodoItems.Add(item);
    }
}