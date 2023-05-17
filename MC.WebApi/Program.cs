
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MC.PersistanceServices;
using MC.PersistanceInterfaces;
using MC.Domain;
using MC.Services.ServicesInterfaces;
using MC.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MovieDbContext>(options =>
{
    var config = builder.Configuration.GetConnectionString("Sql");
    options.UseSqlServer(config);
});

builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IRepository<Movie, Guid>, MovieRepository>();
builder.Services.AddScoped<IMovieService, MovieService>();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "PFS.WebApi", Version = "v1" });
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var dbContext = services.GetRequiredService<MovieDbContext>();
    MovieDbContext.Initialize(dbContext);
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

//app.UseErrorHandlerMiddleware();

app.UseSwagger();
app.UseSwaggerUI();

app.UseRouting();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseAuthorization();

app.MapGet("/hi", () => "Hello!");

app.MapDefaultControllerRoute();

app.Run();