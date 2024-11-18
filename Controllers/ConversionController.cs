using Microsoft.AspNetCore.Mvc;
using conversorMonedas.Exceptions;
using conversorMonedas.Services.Interfaces;
using conversorMonedas.Models.Dtos;

namespace conversorMonedas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConversionController : ControllerBase
    {
        private readonly IConversionService _conversionService;

        public ConversionController(IConversionService conversionService)
        {
            _conversionService = conversionService;
        }

        /// <summary>
        /// Convierte una cantidad de una moneda a otra.
        /// </summary>
        /// <param name="request">Datos para realizar la conversión.</param>
        /// <returns>El monto convertido.</returns>
        [HttpPost]
        public IActionResult ConvertCurrency([FromBody] ConversionRequestDto request)
        {
            try
            {
                var convertedAmount = _conversionService.ConvertCurrency(
                    request.UserId,
                    request.FromCurrencyId,
                    request.ToCurrencyId,
                    request.Amount);

                return Ok(new { ConvertedAmount = convertedAmount });
            }
            catch (ConversionLimitReachedException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
            catch (CurrencyNotFoundException ex)
            {
                return NotFound(new { Message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Ocurrió un error inesperado.", Details = ex.Message });
            }
        }

        /// <summary>
        /// Obtiene el historial de conversiones de un usuario.
        /// </summary>
        /// <param name="userId">ID del usuario.</param>
        /// <returns>Lista de conversiones realizadas por el usuario.</returns>
        [HttpGet("{userId}/history")]
        public IActionResult GetUserConversionHistory(int userId)
        {
            var conversions = _conversionService.GetUserConversions(userId);
            if (conversions == null || !conversions.Any())
            {
                return NotFound(new { Message = "No se encontraron conversiones para este usuario." });
            }
            return Ok(conversions);
        }
    }
}