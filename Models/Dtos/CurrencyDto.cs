namespace conversorMonedas.Models.Dtos
{
    public class CurrencyDto
    {
        public int Id { get; set; } //Este id es el de la moneda
        public string Code { get; set; } //Codigo de la moneda
        public string Symbol { get; set; } //Simbolo de la moneda
        public string Name { get; set; } //Nombre de la moneda
        public decimal ConversionRate { get; set; } //Este es el rate de la conversion
    }
}
