using Microsoft.EntityFrameworkCore;
using Web_RsystemDemoProject.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder => builder.WithOrigins( "http://localhost:4200")
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});

builder.Services.AddControllers(options =>
{
    options.Filters.Add(new GlobalExceptionFilter());
});
builder.Services.AddMemoryCache();

builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IStoriesService, StoriesService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseCors("AllowSpecificOrigin");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseSwagger();
app.UseSwaggerUI(options =>
{

    options.SwaggerEndpoint("swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
    options.DocumentTitle = "My Swagger";

});
app.Run();
