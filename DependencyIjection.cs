using csharpapp.Services;
using csharpapp.Db;
namespace csharpapp.MyDependencyInjection;
public class MyDependencyInjection
{
    public static void Inject(WebApplicationBuilder builder)
    {
        builder.Services.AddSingleton<DatabaseContext, DatabaseContext>();
        builder.Services.AddTransient<ITodoService, TodoService>();
    }
}