using Microsoft.EntityFrameworkCore;
using ServiceStack;
using WorkShop.BL;
using WorkShop.BL.Products;
using WorkShop.Model.Models;
using WorkShop.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

// Add services to the container.
builder.Services.AddCors(options => options.AddPolicy(name: MyAllowSpecificOrigins, builder =>
                builder
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod()));

builder.Services.AddControllers();
builder.Services.AddScoped<IProductBL, ProductBL>();
builder.Services.AddScoped<ILookUpService, LookUpService>();
builder.Services.AddScoped<UnitOfWork>();
builder.Services.AddDbContext<WorkShopContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DatabaseConnection")!);
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseCors(MyAllowSpecificOrigins);

app.Run();
