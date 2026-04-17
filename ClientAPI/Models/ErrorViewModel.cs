namespace ClientAPI.Models // Déclaration de l'espace de noms du module.
{ // Délimiteur de bloc de code.
    public class ErrorViewModel // Déclaration d'une classe.
    { // Délimiteur de bloc de code.
        public string? RequestId { get; set; } // Déclaration d'un membre (propriété, méthode ou champ).

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId); // Déclaration d'un membre (propriété, méthode ou champ).
    } // Délimiteur de bloc de code.
} // Délimiteur de bloc de code.
