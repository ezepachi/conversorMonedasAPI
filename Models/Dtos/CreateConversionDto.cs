namespace conversorMonedas.Models.Dtos
{
    public class CreateConversionDto
    {
        public int Id { get; set; } //Este id es el de la conversion
        public int SourceCurrencyId { get; set; } //Este id es el de la moneda de origen
        public int TargetCurrencyId { get; set; } //Este id es el de la moneda de destino
        public decimal Amount { get; set; } //Este es el monto a convertir
        public decimal ConversionRate { get; set; } //Este es el rate de la conversion
        public decimal ConvertedAmount { get; set; } //Este es el resultado de la conversion
        public int UserId { get; set; } //Este id es el del usuario
        public DateTime CreatedAt { get; set; }
    }
}