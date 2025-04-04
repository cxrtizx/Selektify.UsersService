using BusinessLogicLayer;
using Selektify.UsersService.Middleware;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddBusinessLogicLayer();
builder.Services.AddControllers();
var app = builder.Build();

app.UseExceptionHandlingMiddleware();
app.UseRouting();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
