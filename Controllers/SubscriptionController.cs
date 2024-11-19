using conversorMonedas.Entities;
using conversorMonedas.Models.Dtos;
using conversorMonedas.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace conversorMonedas.Controllers;



[ApiController]
[Route("api/[controller]")]
public class SubscriptionController : ControllerBase
{
    private readonly ISubscriptionService _subscriptionService;

    public SubscriptionController(ISubscriptionService subscriptionService)
    {
        _subscriptionService = subscriptionService;
    }

    /// <summary>
    /// Obtiene la suscripción de un usuario por su ID.
    /// </summary>
    /// <param name="userId">ID del usuario.</param>
    /// <returns>La suscripción del usuario.</returns>
    [HttpGet("{userId}")]
    public IActionResult GetUserSubscription(int userId)
    {
        var subscription = _subscriptionService.GetUserSubscription(userId);
        if (subscription == null)
        {
            return NotFound(new { Message = $"No se encontró una suscripción para el usuario con ID {userId}." });
        }

        return Ok(subscription);
    }
    
    /// <summary>
    /// Actualiza la suscripción de un usuario.
    /// </summary>
    /// <param name="userId">ID del usuario.</param>
    /// <param name="newSubscription">Detalles de la nueva suscripción.</param>
    /// <returns>Mensaje de éxito o error.</returns>
    [HttpPut("{userId}")]
    public IActionResult UpdateUserSubscription(int userId, [FromBody] UpdateSubscriptionDto subscriptionDto)
    {
        try
        {
            // Crear una nueva instancia de Subscription a partir del DTO
            var updatedSubscription = new Subscription
            {
                Type = subscriptionDto.Type,
                ExpirationDate = subscriptionDto.ExpirationDate
            };

            _subscriptionService.UpdateSubscription(userId, updatedSubscription);

            return Ok(new { Message = "Suscripción actualizada con éxito." });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Message = "Ocurrió un error al actualizar la suscripción.", Details = ex.Message });
        }
    }


    /// <summary>
    /// Verifica si un usuario puede realizar conversiones.
    /// </summary>
    /// <param name="userId">ID del usuario.</param>
    /// <returns>Estado de la conversión.</returns>
    [HttpGet("{userId}/can-convert")]
    public IActionResult CanUserConvert(int userId)
    {
        var canConvert = _subscriptionService.CanUserConvert(userId);

        return Ok(new { CanConvert = canConvert });
    }
}