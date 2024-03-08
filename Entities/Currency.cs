using conversorDeMonedas.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace conversorMonedas.Entities
{
    public class Currency
    {
        // colocar el id de la moneda como clave primaria y que sea autoincremental haciendo lo siguiente: 
        // La moneda va a tener código, leyenda, símbolo  y un índice de convertibilidad (IC) 
        //que va permitir convertir de una moneda a otra.
        //Este índice será guardado en la base de datos de manera estática para fines didácticos pero la idea sería que 
        //se pueda actualizar según varia las monedas
       // El índice de convertibilidad será la relación que existe entre una moneda y el dólar americano expresada en 
        //cuánto vale una unidad de dicha moneda en comparación a 1 usd.

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int  IdCurrency { get; set; }
        public string Code { get; set; }
        public string Legend { get; set; }
        public string Symbol { get; set; }
        public float Ic { get; set; }


        public List<Conversion> ConversionsFrom { get; set; }
        public List<Conversion> ConversionsTo { get; set; }
        public List<User> UsersFav { get; set; }
 
    }
}

//IC para Ars (Peso Argentino): 0.002
//IC para Eur(Euro): 1.09
//IC para Kc (Corona Checa): 0.043
//IC para USD(Dólar Americano): 1
