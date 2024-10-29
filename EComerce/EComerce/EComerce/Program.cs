using EComerce.Datas;
using EComerce.Interfaces;
using EComerce.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Services.AddDbContext<ApplicationDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
  

});


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigins",
            builder =>
            {
                builder.WithOrigins("http://127.0.0.1:5500")
                       .AllowAnyHeader()
                       .AllowAnyMethod();
            });
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.UseCors("AllowSpecificOrigins");


app.UseAuthorization();

app.MapControllers();

app.Run();


