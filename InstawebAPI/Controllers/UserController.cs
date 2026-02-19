using InstawebAPI.DTOs;
using InstawebAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebMVC.Services;

namespace InstawebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        //[Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Users()
        {
            var users = await _userService.GetAllUser();
            return Ok(users);
        }


        [HttpPost]
        public async Task<IActionResult> CreateClient([FromBody] UserClientDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var produitCree = await _userService.CreerClient(dto);

                return StatusCode(201, $"L'utilisateur a été créer avec success");

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        //[Authorize(Roles = "Admin")]
      /* [HttpPost]
        public async Task<IActionResult> CreateAdmin([FromBody] UserAdminDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var produitCree = await _userService.CreerAdmin(dto);

                return StatusCode(201, $"L'utilisateur a été créer avec success");

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }*/

      /*[HttpPut("{id}")]
        public async Task<IActionResult> UpdateClient(int id, [FromBody] UserClientDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState); // 400

            try
            {
                var updated = await _userService.UpdateClient(id, dto);

                if (updated == null)
                    return NotFound(); // 404

                return Ok(updated); // 200 + JSON
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Impossible de contacter le serveur d’authentification.");
                return StatusCode(500, new { message = ex.Message }); // 500
            }
        }*/

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAdmin(int id, [FromBody] UserAdminDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState); // 400

            try
            {
                var updated = await _userService.UpdateAdmin(id, dto);

                if (updated == null)
                    return NotFound(); // 404

                return Ok(updated); // 200 + JSON
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Impossible de contacter le serveur d’authentification.");
                return StatusCode(500, new { message = ex.Message }); // 500
            }
        }

       

    }
}
