using conversorMonedas.Data;
using conversorMonedas.Entities;
using conversorMonedas.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using conversorMonedas.Exceptions;
public class ConversionService : IConversionService
{
    private readonly ConversorContext _context;
    private readonly ICurrencyService _currencyService;
    private readonly ISubscriptionService _subscriptionService;

    public ConversionService(
        ConversorContext context, 
        ICurrencyService currencyService, 
        ISubscriptionService subscriptionService)
    {
        _context = context;
        _currencyService = currencyService;
        _subscriptionService = subscriptionService;
    }

    public decimal ConvertCurrency(int userId, int fromCurrencyId, int toCurrencyId, decimal amount)
    {
        // Validar si el usuario puede realizar conversiones
        if (!_subscriptionService.CanUserConvert(userId))
            throw new ConversionLimitReachedException("Límite de conversiones completado por hoy.");

        // Obtener las monedas
        var fromCurrency = _currencyService.GetCurrencyById(fromCurrencyId);
        var toCurrency = _currencyService.GetCurrencyById(toCurrencyId);

        if (fromCurrency == null)
            throw new CurrencyNotFoundException($"La moneda con ID {fromCurrencyId} no existe.");
        
        if (toCurrency == null)
            throw new CurrencyNotFoundException($"La moneda con ID {toCurrencyId} no existe.");

        // Calcular el monto convertido
        var conversionRate = toCurrency.ConvertibilityIndex / fromCurrency.ConvertibilityIndex;
        var convertedAmount = amount * conversionRate;

        // Registrar la conversión en la base de datos
        var conversion = new Conversion
        {
            UserId = userId,
            FromCurrencyId = fromCurrencyId,
            ToCurrencyId = toCurrencyId,
            Amount = amount,
            ConvertedAmount = convertedAmount,
            Timestamp = DateTime.Now
        };

        _context.Conversions.Add(conversion);
        _context.SaveChanges();

        return convertedAmount;
    }
    
    public IEnumerable<Conversion> GetUserConversions(int userId)
    {
        return _context.Conversions
            .Where(c => c.UserId == userId)
            .OrderByDescending(c => c.Timestamp)
            .ToList();
    }
}