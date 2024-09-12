using conversorDeMonedas.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace conversorMonedas.Entities
{
    public class Currency
    {
        public int Id { get; set; }
        public string Code { get; set; } // Código de la moneda (e.g., USD)
        public string Legend { get; set; } // Nombre completo (e.g., Dólar Americano)
        public string Symbol { get; set; } // Símbolo (e.g., $)
        public decimal ConvertibilityIndex { get; set; } // Índice de convertibilidad
    }

}

//IC para Ars (Peso Argentino): 0.002
//IC para Eur(Euro): 1.09
//IC para Kc (Corona Checa): 0.043
//IC para USD(Dólar Americano): 1
