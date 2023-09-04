using System.Data;

namespace Api.Middlewares;

public class DBMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IConfiguration _configuration;

    public DBMiddleware(RequestDelegate next,IConfiguration configuration)
    {
        _next = next;
        _configuration = configuration;
    }
    
    public async Task InvokeAsync(HttpContext context)
    {
        Console.WriteLine(context.Request.Path);
        Console.WriteLine(context.Request.Host.Host);
       var dbConnection =  context.RequestServices.GetService<IDbConnection>();
       dbConnection.ConnectionString = _configuration["ConnectionString"];
      await  _next.Invoke(context);
      dbConnection.Close();
    }
}

 