using InstawebAPI.DTOs; // Instruction métier conservée telle quelle.
using InstawebAPI.Services; // Importation d'un espace de noms nécessaire.
using Microsoft.AspNetCore.Authorization; // Importation d'un espace de noms nécessaire.
using Microsoft.AspNetCore.Http; // Importation d'un espace de noms nécessaire.
using Microsoft.AspNetCore.Mvc; // Importation d'un espace de noms nécessaire.
using WebMVC.Services; // Importation d'un espace de noms nécessaire.

namespace InstawebAPI.Controllers // Déclaration de l'espace de noms du module.
{ // Délimiteur de bloc de code.
    [Route("api/[controller]")] // Attribut de configuration/annotation appliqué.
    [ApiController] // Attribut de configuration/annotation appliqué.
    public class UserController : ControllerBase // Déclaration d'une classe.
    { // Délimiteur de bloc de code.
        private readonly IUserService _userService; // Déclaration d'un membre (propriété, méthode ou champ).

        public UserController(IUserService userService) // Déclaration d'un membre (propriété, méthode ou champ).
        { // Délimiteur de bloc de code.
            _userService = userService; // Instruction métier conservée telle quelle.
        } // Délimiteur de bloc de code.

        //[Authorize(Roles = "Admin")]
        [HttpGet] // Attribut de configuration/annotation appliqué.
        public async Task<IActionResult> Users() // Déclaration d'un membre (propriété, méthode ou champ).
        { // Délimiteur de bloc de code.
            var users = await _userService.GetAllUser(); // Déclaration et/ou initialisation de variable locale.
            return Ok(users); // Retour de la valeur calculée.
        } // Délimiteur de bloc de code.


        [HttpPost] // Attribut de configuration/annotation appliqué.
        public async Task<IActionResult> CreateClient([FromBody] UserClientDto dto) // Déclaration d'un membre (propriété, méthode ou champ).
        { // Délimiteur de bloc de code.
            if (!ModelState.IsValid) // Condition pour contrôler le flux d'exécution.
                return BadRequest(ModelState); // Retour de la valeur calculée.

            try // Instruction métier conservée telle quelle.
            { // Délimiteur de bloc de code.
                var produitCree = await _userService.CreerClient(dto); // Déclaration et/ou initialisation de variable locale.

                return StatusCode(201, $"L'utilisateur a été créer avec success"); // Retour de la valeur calculée.

            } // Délimiteur de bloc de code.
            catch (Exception ex) // Instruction métier conservée telle quelle.
            { // Délimiteur de bloc de code.
                return StatusCode(500, new { message = ex.Message }); // Retour de la valeur calculée.
            } // Délimiteur de bloc de code.
        } // Délimiteur de bloc de code.

        //[Authorize(Roles = "Admin")]
      /* [HttpPost]
        public async Task<IActionResult> CreateAdmin([FromBody] UserAdminDto dto) // Déclaration d'un membre (propriété, méthode ou champ).
        { // Délimiteur de bloc de code.
            if (!ModelState.IsValid) // Condition pour contrôler le flux d'exécution.
                return BadRequest(ModelState); // Retour de la valeur calculée.

            try // Instruction métier conservée telle quelle.
            { // Délimiteur de bloc de code.
                var produitCree = await _userService.CreerAdmin(dto); // Déclaration et/ou initialisation de variable locale.

                return StatusCode(201, $"L'utilisateur a été créer avec success"); // Retour de la valeur calculée.

            } // Délimiteur de bloc de code.
            catch (Exception ex) // Instruction métier conservée telle quelle.
            { // Délimiteur de bloc de code.
                return StatusCode(500, new { message = ex.Message }); // Retour de la valeur calculée.
            } // Délimiteur de bloc de code.
        }*/ // Instruction métier conservée telle quelle.

      /*[HttpPut("{id}")]
        public async Task<IActionResult> UpdateClient(int id, [FromBody] UserClientDto dto) // Déclaration d'un membre (propriété, méthode ou champ).
        { // Délimiteur de bloc de code.
            if (!ModelState.IsValid) // Condition pour contrôler le flux d'exécution.
                return BadRequest(ModelState); // 400

            try // Instruction métier conservée telle quelle.
            { // Délimiteur de bloc de code.
                var updated = await _userService.UpdateClient(id, dto); // Déclaration et/ou initialisation de variable locale.

                if (updated == null) // Condition pour contrôler le flux d'exécution.
                    return NotFound(); // 404

                return Ok(updated); // 200 + JSON
            } // Délimiteur de bloc de code.
            catch (Exception ex) // Instruction métier conservée telle quelle.
            { // Délimiteur de bloc de code.
                ModelState.AddModelError("", "Impossible de contacter le serveur d’authentification."); // Instruction métier conservée telle quelle.
                return StatusCode(500, new { message = ex.Message }); // 500
            } // Délimiteur de bloc de code.
        }*/ // Instruction métier conservée telle quelle.

        [HttpPut("{id}")] // Attribut de configuration/annotation appliqué.
        public async Task<IActionResult> UpdateAdmin(int id, [FromBody] UserAdminDto dto) // Déclaration d'un membre (propriété, méthode ou champ).
        { // Délimiteur de bloc de code.
            if (!ModelState.IsValid) // Condition pour contrôler le flux d'exécution.
                return BadRequest(ModelState); // 400

            try // Instruction métier conservée telle quelle.
            { // Délimiteur de bloc de code.
                var updated = await _userService.UpdateAdmin(id, dto); // Déclaration et/ou initialisation de variable locale.

                if (updated == null) // Condition pour contrôler le flux d'exécution.
                    return NotFound(); // 404

                return Ok(updated); // 200 + JSON
            } // Délimiteur de bloc de code.
            catch (Exception ex) // Instruction métier conservée telle quelle.
            { // Délimiteur de bloc de code.
                ModelState.AddModelError("", "Impossible de contacter le serveur d’authentification."); // Instruction métier conservée telle quelle.
                return StatusCode(500, new { message = ex.Message }); // 500
            } // Délimiteur de bloc de code.
        } // Délimiteur de bloc de code.

       

    } // Délimiteur de bloc de code.
} // Délimiteur de bloc de code.
