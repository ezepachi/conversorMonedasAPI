using System;

namespace conversorMonedas.Models.Dtos
{
    public class UpdateSubscriptionDto
    {
        public string Type { get; set; } // Free, Trial, Pro
        public DateTime ExpirationDate { get; set; } // Fecha de expiración para Trial
    }
}