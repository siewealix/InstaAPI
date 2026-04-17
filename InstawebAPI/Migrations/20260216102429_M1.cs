using Microsoft.EntityFrameworkCore.Migrations; // Instruction métier conservée telle quelle.

#nullable disable // Directive de compilation/préprocesseur.

namespace InstawebAPI.Migrations // Déclaration de l'espace de noms du module.
{ // Délimiteur de bloc de code.
    /// <inheritdoc />
    public partial class M1 : Migration // Déclaration d'un membre (propriété, méthode ou champ).
    { // Délimiteur de bloc de code.
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder) // Déclaration d'un membre (propriété, méthode ou champ).
        { // Délimiteur de bloc de code.
            migrationBuilder.CreateTable( // Instruction de migration de base de données.
                name: "Produits", // Instruction métier conservée telle quelle.
                columns: table => new // Instruction métier conservée telle quelle.
                { // Délimiteur de bloc de code.
                    Id = table.Column<int>(type: "int", nullable: false) // Instruction métier conservée telle quelle.
                        .Annotation("SqlServer:Identity", "1, 1"), // Instruction métier conservée telle quelle.
                    Nom = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false), // Instruction métier conservée telle quelle.
                    Prix = table.Column<decimal>(type: "decimal(18,2)", nullable: false), // Instruction métier conservée telle quelle.
                    Stock = table.Column<int>(type: "int", nullable: false) // Instruction métier conservée telle quelle.
                }, // Instruction métier conservée telle quelle.
                constraints: table => // Instruction métier conservée telle quelle.
                { // Délimiteur de bloc de code.
                    table.PrimaryKey("PK_Produits", x => x.Id); // Instruction métier conservée telle quelle.
                }); // Instruction métier conservée telle quelle.
        } // Délimiteur de bloc de code.

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder) // Déclaration d'un membre (propriété, méthode ou champ).
        { // Délimiteur de bloc de code.
            migrationBuilder.DropTable( // Instruction de migration de base de données.
                name: "Produits"); // Instruction métier conservée telle quelle.
        } // Délimiteur de bloc de code.
    } // Délimiteur de bloc de code.
} // Délimiteur de bloc de code.
