using conversorMonedas.Entities;
using System.Collections.Generic;

namespace conversorMonedas.Services.Interfaces
{
    public interface IConversionService
    {
        /// <summary>
        /// Convierte una cantidad de una moneda a otra.
        /// </summary>
        /// <param name="userId">ID del usuario que realiza la conversión.</param>
        /// <param name="fromCurrencyId">ID de la moneda de origen.</param>
        /// <param name="toCurrencyId">ID de la moneda de destino.</param>
        /// <param name="amount">Cantidad a convertir.</param>
        /// <returns>Monto convertido.</returns>
        decimal ConvertCurrency(int userId, int fromCurrencyId, int toCurrencyId, decimal amount);

        /// <summary>
        /// Devuelve el historial de conversiones de un usuario.
        /// </summary>
        /// <param name="userId">ID del usuario.</param>
        /// <returns>Lista de conversiones del usuario.</returns>
        IEnumerable<Conversion> GetUserConversions(int userId);
    }
}