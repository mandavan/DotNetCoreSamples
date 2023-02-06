using Microsoft.AspNetCore.Http;
using System.Runtime.CompilerServices;
using ToDoAPI.Controllers;
using ToDoAPI.Interfaces;
using ToDoAPI.Middleware;
using static System.Net.Mime.MediaTypeNames;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ITest, TestClass>();
builder.Services.AddSingleton<ISingleTon, SingleTon>();
builder.Services.AddScoped<IScoped, Scoped>();
builder.Services.AddTransient<ITransiant, Transiant>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
/*app.Use(async (context, next) =>
{
    await Invoke1(context);
    await next.Invoke();
});*/
//app.Map("/Test", MapExecutor);
//app.Run()
app.UseAuthorization();
//app.Use(Invoke0);
app.Use((httpContext, next) =>
{
    //httpContext.Request.Body
    httpContext.Response.WriteAsync("MiddlewareData: test1");
    return next.Invoke();
    //httpContext.Response.WriteAsync("MiddlewareData: test2");
});
//app.Run(Invoke1);
app.MapControllers();

app.Run();

void MapExecutor(IApplicationBuilder builder)
{
    builder.Run(async context =>
    {
        await Invoke2(context);
    });
}

async Task Invoke0(HttpContext httpContext, dynamic next)
{
    
    await httpContext.Response.WriteAsync("MiddlewareData: test");
    await next.Invoke();
}

async Task Invoke1(HttpContext httpContext)
{

    await httpContext.Response.WriteAsync("MiddlewareData: test1");
}

async Task Invoke2(HttpContext httpContext)
{

    await httpContext.Response.WriteAsync("MiddlewareData: test1");
}
