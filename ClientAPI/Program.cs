using ClientAPI.Services; // Importation d'un espace de noms nécessaire.


var builder = WebApplication.CreateBuilder(args); // Déclaration et/ou initialisation de variable locale.

// Add services to the container.
builder.Services.AddControllersWithViews(); // Configuration du pipeline et des services de l'application.

builder.Services.AddHttpClient<ProduitAPIClient>(client => // Configuration du pipeline et des services de l'application.

client.BaseAddress = new Uri("https://localhost:7225/"));


var app = builder.Build(); // Déclaration et/ou initialisation de variable locale.

// Configure the HTTP request pipeline.
   if (!app.Environment.IsDevelopment()) // Condition pour contrôler le flux d'exécution.
            { // Délimiteur de bloc de code.
                app.UseExceptionHandler("/Home/Error"); // Configuration du pipeline et des services de l'application.
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts(); // Configuration du pipeline et des services de l'application.
            } // Délimiteur de bloc de code.

   app.UseHttpsRedirection(); // Configuration du pipeline et des services de l'application.
   app.UseStaticFiles(); // Configuration du pipeline et des services de l'application.

   app.UseRouting(); // Configuration du pipeline et des services de l'application.

   app.UseAuthorization(); // Configuration du pipeline et des services de l'application.

   app.MapControllerRoute( // Configuration du pipeline et des services de l'application.
                name: "default", // Instruction métier conservée telle quelle.
                pattern: "{controller=Produit}/{action=Index}/{id?}"); // Instruction métier conservée telle quelle.

   app.Run(); // Configuration du pipeline et des services de l'application.
