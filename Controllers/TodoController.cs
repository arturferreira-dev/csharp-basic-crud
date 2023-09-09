using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using csharpapp.Models;
using csharpapp.Services;


namespace csharpapp.Controllers;
[Controller()]
[Route("todo")]
public class TodoController : Controller
{
    private readonly ILogger<TodoController> _logger;
    private readonly ITodoService _todoService;
    public TodoController(ILogger<TodoController> logger, IConfiguration config, ITodoService todoService)
    {
        _logger = logger;
        _todoService = todoService;
    }

    [HttpGet]
    public IActionResult Index()
    {
        List<Todo>? todos = _todoService.List();
        return Ok(todos);
    }
    [HttpGet("{id}")]
    public IActionResult Detail(int id)
    {
        Todo? todo = _todoService.Detail(id);
        if (todo == null)
        {
            return NotFound();
        }
        return Ok(todo);
    }
    [HttpPost]
    public IActionResult Create([FromBody] Todo todo)
    {
        Todo todoCreated = _todoService.Create(todo);
        return Ok(todoCreated);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] Todo todo)
    {
        Todo? todoUpdated = _todoService.Update(id, todo);
        if (todoUpdated == null)
        {
            return NotFound();
        }
        return Ok(todoUpdated);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        Todo? todoDelete = _todoService.Delete(id);
        if (todoDelete == null)
        {
            return NotFound();
        }
        return Ok(todoDelete);
    }
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
