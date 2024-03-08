﻿using conversorMonedas.Models.Dtos;
using IdentityServer3.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AgendaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userRepository)
        {
            _userService = userRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_userService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetOneById(int id)
        {
            if (id == 0)
            {
                return BadRequest("El ID ingresado debe ser distinto de 0");
            }

            User? user = _userService.GetById(id);

            if (user is null)
            {
                return NotFound();
            }

            var dto = new GetUserByIdResponse()
            {
                Apellido = user.LastName,
                Nombre = user.FirstName,
                NombreDeUsuario = user.UserName,
                Estado = user.State,
                Id = user.Id,
                Contactos = user.Contacts,
                Rol = user.Rol
            };

            return Ok(dto);

        }

        [HttpPost]
        public IActionResult CreateUser(CreateAndUpdateUserDto dto)
        {
            try
            {
                _userService.Create(dto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            return Created("Created", dto);
        }

        [HttpPut("{userId}")]
        public IActionResult UpdateUser(CreateAndUpdateUserDto dto, int userId)
        {
            if (!_userService.CheckIfUserExists(userId))
            {
                return NotFound();
            }
            try
            {
                _userService.Update(dto, userId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            return NoContent();
        }

        [HttpDelete]
        public IActionResult DeleteUser(int id)
        {
            User? user = _userService.GetById(id);
            if (user is null)
            {
                return BadRequest("El cliente que intenta eliminar no existe");
            }

            if (user.FirstName != "Admin")
            {
                _userService.Delete(id);
            }
            else
            {
                _userService.Archive(id);
            }
            return NoContent();
        }
    }
}
