using Selektify.UsersService.Middleware;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseExceptionHandlingMiddleware();

app.Run();
