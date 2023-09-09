namespace csharpapp.Services;
using Db;
using Models;

public interface ITodoService
{
    Todo Create(Todo todo);
    List<Todo> List();
    Todo? Detail(int id);
    Todo? Update(int id, Todo todo);
    Todo? Delete(int id);
}
public class TodoService : ITodoService
{
    private readonly DatabaseContext _db;
    public TodoService(DatabaseContext db)
    {
        this._db = db;
    }

    public Todo Create(Todo todo)
    {
        _db.Add(todo);
        _db.SaveChanges();
        return todo;
    }

    public Todo? Delete(int id)
    {
        Todo? todoToDelete = _db.Todo.Where(item => item.TodoId == id).FirstOrDefault();
        if (todoToDelete == null)
        {
            return null;
        }
        _db.Todo.Remove(todoToDelete);
        _db.SaveChanges();
        return todoToDelete;
    }

    public Todo? Detail(int id)
    {
        Todo? todo = _db.Todo.Where(item => item.TodoId == id).FirstOrDefault();
        return todo ?? null;
    }

    public List<Todo> List()
    {
        List<Todo> todo = _db.Todo.ToList();
        return todo;
    }

    public Todo? Update(int id, Todo todo)
    {
        Todo? todoToUpdate = _db.Todo.Where(item => item.TodoId == id).FirstOrDefault();
        if (todoToUpdate == null)
        {
            return null;
        }
        Console.WriteLine(_db.DbPath);
        todoToUpdate.Name = todo.Name;
        todoToUpdate.TodoItems = todo?.TodoItems ?? new();
        _db.Update(todoToUpdate);
        // _db.SaveChanges();
        return todoToUpdate;
    }
}