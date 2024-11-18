namespace conversorMonedas.Models.Dtos
{
    public class ConversionRequestDto
    {
        /// <summary>
        /// ID del usuario que realiza la conversión.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// ID de la moneda de origen.
        /// </summary>
        public int FromCurrencyId { get; set; }

        /// <summary>
        /// ID de la moneda de destino.
        /// </summary>
        public int ToCurrencyId { get; set; }

        /// <summary>
        /// Cantidad a convertir.
        /// </summary>
        public decimal Amount { get; set; }
    }
}