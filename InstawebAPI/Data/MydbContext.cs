using Microsoft.EntityFrameworkCore; // Instruction métier conservée telle quelle.
using InstawebAPI.Models; // Importation d'un espace de noms nécessaire.

namespace InstawebAPI.Data // Déclaration de l'espace de noms du module.
{ // Délimiteur de bloc de code.
    public class MydbContext : DbContext // Déclaration d'une classe.
    { // Délimiteur de bloc de code.
        public MydbContext(DbContextOptions<MydbContext> options) : base(options) // Déclaration d'un membre (propriété, méthode ou champ).
        { // Délimiteur de bloc de code.


        } // Délimiteur de bloc de code.

       public DbSet<Produit> Produits { get; set; } // Déclaration d'un membre (propriété, méthode ou champ).
       public DbSet<User> Users { get; set; } // Déclaration d'un membre (propriété, méthode ou champ).


    } // Délimiteur de bloc de code.
} // Délimiteur de bloc de code.
