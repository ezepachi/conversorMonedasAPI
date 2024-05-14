namespace conversorMonedas.Models.Dtos
{
    public class SubscriptionDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; } 
        public int ConversionLimit { get; set; } //Este es el limite de conversiones
        public decimal Price { get; set; } //Este es el precio de la suscripcion
    }
}
