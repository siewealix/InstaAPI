using Microsoft.AspNetCore.Mvc; // Importation d'un espace de noms nécessaire.

namespace InstawebAPI.Controllers // Déclaration de l'espace de noms du module.
{ // Délimiteur de bloc de code.
    [ApiController] // Attribut de configuration/annotation appliqué.
    [Route("[controller]")] // Attribut de configuration/annotation appliqué.
    public class WeatherForecastController : ControllerBase // Déclaration d'une classe.
    { // Délimiteur de bloc de code.
        private static readonly string[] Summaries = new[] // Déclaration d'un membre (propriété, méthode ou champ).
        { // Délimiteur de bloc de code.
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching" // Instruction métier conservée telle quelle.
        }; // Instruction métier conservée telle quelle.

        private readonly ILogger<WeatherForecastController> _logger; // Déclaration d'un membre (propriété, méthode ou champ).

        public WeatherForecastController(ILogger<WeatherForecastController> logger) // Déclaration d'un membre (propriété, méthode ou champ).
        { // Délimiteur de bloc de code.
            _logger = logger; // Instruction métier conservée telle quelle.
        } // Délimiteur de bloc de code.

        [HttpGet(Name = "GetWeatherForecast")] // Attribut de configuration/annotation appliqué.
        public IEnumerable<WeatherForecast> Get() // Déclaration d'un membre (propriété, méthode ou champ).
        { // Délimiteur de bloc de code.
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast // Retour de la valeur calculée.
            { // Délimiteur de bloc de code.
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)), // Instruction métier conservée telle quelle.
                TemperatureC = Random.Shared.Next(-20, 55), // Instruction métier conservée telle quelle.
                Summary = Summaries[Random.Shared.Next(Summaries.Length)] // Instruction métier conservée telle quelle.
            }) // Instruction métier conservée telle quelle.
            .ToArray(); // Instruction métier conservée telle quelle.
        } // Délimiteur de bloc de code.
    } // Délimiteur de bloc de code.
} // Délimiteur de bloc de code.
