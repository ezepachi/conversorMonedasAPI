using Microsoft.AspNetCore.Mvc;
using conversorMonedas.Interfaces;
using conversorMonedas.Models.Dtos;

namespace conversorMonedas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var users = _userService.GetAllUsers();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            var user = _userService.GetUserById(id);
            if (user == null)
            {
                return NotFound("Usuario no encontrado.");
            }
            return Ok(user);
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] CreateAndUpdateUserDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _userService.CreateUser(dto);
            return Ok("Usuario creado exitosamente.");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, [FromBody] CreateAndUpdateUserDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _userService.UpdateUser(dto, id);
            return Ok("Usuario actualizado exitosamente.");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            _userService.DeleteUser(id);
            return Ok("Usuario eliminado exitosamente.");
        }

        [HttpPost("validate")]
        public IActionResult ValidateUser([FromBody] AuthenticationRequestBodyDto authRequestBody)
        {
            var user = _userService.ValidateUser(authRequestBody);
            if (user == null)
            {
                return Unauthorized("Credenciales inválidas.");
            }
            return Ok(user);
        }

        [HttpPatch("{id}/subscription")]
        public IActionResult UpdateUserSubscription(int id, [FromBody] int subscriptionId)
        {
            _userService.UpdateUserSubscription(id, subscriptionId);
            return Ok("Suscripción actualizada exitosamente.");
        }
    }
}