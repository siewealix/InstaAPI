using InstawebAPI.Data;
using InstawebAPI.Services;
using Microsoft.EntityFrameworkCore;
using WebMVC.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddScoped<IProduitService, ProduitService>();
builder.Services.AddScoped<IUserService, UserService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Ajouter le service EF (Entity Framework)
builder.Services.AddDbContext<MydbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Mycn")));

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

app.Run();
