
namespace conversorMonedas.Entities;

public class FavoriteCurrency
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
    public int CurrencyId { get; set; }
    public Currency Currency { get; set; }
}