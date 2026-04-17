using InstawebAPI.Data; // Instruction métier conservée telle quelle.
using InstawebAPI.Services; // Importation d'un espace de noms nécessaire.
using Microsoft.EntityFrameworkCore; // Importation d'un espace de noms nécessaire.
using WebMVC.Services; // Importation d'un espace de noms nécessaire.

var builder = WebApplication.CreateBuilder(args); // Déclaration et/ou initialisation de variable locale.

// Add services to the container.
builder.Services.AddControllers(); // Configuration du pipeline et des services de l'application.
builder.Services.AddScoped<IProduitService, ProduitService>(); // Configuration du pipeline et des services de l'application.
builder.Services.AddScoped<IUserService, UserService>(); // Configuration du pipeline et des services de l'application.

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer(); // Configuration du pipeline et des services de l'application.
builder.Services.AddSwaggerGen(); // Configuration du pipeline et des services de l'application.

// Ajouter le service EF (Entity Framework)
builder.Services.AddDbContext<MydbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Mycn"))); // Configuration du pipeline et des services de l'application.

var app = builder.Build(); // Déclaration et/ou initialisation de variable locale.

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) // Condition pour contrôler le flux d'exécution.
{ // Délimiteur de bloc de code.
    app.UseSwagger(); // Configuration du pipeline et des services de l'application.
    app.UseSwaggerUI(); // Configuration du pipeline et des services de l'application.
} // Délimiteur de bloc de code.

app.UseHttpsRedirection(); // Configuration du pipeline et des services de l'application.

app.UseAuthorization(); // Configuration du pipeline et des services de l'application.

app.MapControllers(); // Configuration du pipeline et des services de l'application.

app.Run(); // Configuration du pipeline et des services de l'application.
