using Microsoft.EntityFrameworkCore;
using ShopOnline.Api.Data;
using ShopOnline.Api.Repositories;
using ShopOnline.Api.Repositories.Contracts;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(); //add by ibson
builder.Services.AddEndpointsApiExplorer(); //add by ibson
builder.Services.AddSwaggerGen(); //add by ibson
// Add services to the container.
//builder.Services.AddRazorPages();

builder.Services.AddDbContextPool<ShopOnlineDbContext>(options =>
   options.UseSqlServer(builder.Configuration.GetConnectionString("ShopOnlineConnection"))); //add by ibson

builder.Services.AddScoped<IProductRepository, ProductRepository>(); //add by ibson

var app = builder.Build();

// Configure the HTTP request pipeline.
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); //add by ibson
    app.UseSwaggerUI(options => //add by ibson
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "ShopOnline API");
    });
}
 
app.UseHttpsRedirection(); //add by ibson

app.UseAuthorization(); //add by ibson

app.MapControllers(); //add by ibson

app.Run();
