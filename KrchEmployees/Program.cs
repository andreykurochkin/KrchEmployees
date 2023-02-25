using KrchEmployees.Extensions;
using Microsoft.AspNetCore.HttpOverrides;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.ConfigureCors();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseForwardedHeaders(new ForwardedHeadersOptions()
{
    ForwardedHeaders = ForwardedHeaders.All,
});
app.UseCors("CorsPolicy");
app.UseAuthorization();
app.Use(async (context, next) =>
{
    Console.WriteLine($"Logic before executing the next delegate in the Use method");
    await next.Invoke();
    Console.WriteLine("Login after executing next delegate in the Use method");
});
app.Map("/usingmapbranch", builder =>
{
    builder.Use(async (ContextCallback, next) =>
    {
        Console.WriteLine("Map branch logic in the Use method before the next delegate");
        await next.Invoke();
        Console.WriteLine("Map branch logic in the Use method after the next delegate");
    });
    builder.Run(async context =>
    {
        Console.WriteLine("Map branch response to the client in the Run method");
        await context.Response.WriteAsync("Hello from the map branch.");
    });
});
app.MapWhen(
    context => context.Request.Query.ContainsKey("testquerystring"),
    builder =>
    {
        builder.Run(async context =>
        {
            await context.Response.WriteAsJsonAsync("Hello from the MapWhen branch.");
        });
    }
);
app.Run(async context =>
{
    Console.WriteLine("Writing the response to the client in the Run method");
    await context.Response.WriteAsync("Hello from the middleware component");
});
app.MapControllers();

app.Run();