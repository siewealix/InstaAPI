namespace InstawebAPI // Déclaration de l'espace de noms du module.
{ // Délimiteur de bloc de code.
    public class WeatherForecast // Déclaration d'une classe.
    { // Délimiteur de bloc de code.
        public DateOnly Date { get; set; } // Déclaration d'un membre (propriété, méthode ou champ).

        public int TemperatureC { get; set; } // Déclaration d'un membre (propriété, méthode ou champ).

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556); // Déclaration d'un membre (propriété, méthode ou champ).

        public string? Summary { get; set; } // Déclaration d'un membre (propriété, méthode ou champ).
    } // Délimiteur de bloc de code.
} // Délimiteur de bloc de code.
