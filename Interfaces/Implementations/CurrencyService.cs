using conversorMonedas.Data;
using conversorMonedas.Entities;
using conversorMonedas.Services.Interfaces;

namespace conversorMonedas.Interfaces.Implementations;

public class CurrencyService : ICurrencyService
{
    private readonly ConversorContext _context;

    public CurrencyService(ConversorContext context)
    {
        _context = context;
    }

    public List<Currency> GetAllCurrencies()
    {
        return _context.Currencies.ToList();
    }

    public bool AddCurrency(Currency currency)
    {
        try
        {
            _context.Currencies.Add(currency);
            _context.SaveChanges();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
    
    public bool UpdateCurrency(int id, Currency updatedCurrency)
    {
        var existingCurrency = _context.Currencies.FirstOrDefault(c => c.Id == id);
    
        if (existingCurrency == null)
        {
            return false;
        }

        existingCurrency.Code = updatedCurrency.Code;
        existingCurrency.Legend = updatedCurrency.Legend;
        existingCurrency.Symbol = updatedCurrency.Symbol;
        existingCurrency.ConvertibilityIndex = updatedCurrency.ConvertibilityIndex;

        _context.SaveChanges();
        return true;
    }
    
    public bool DeleteCurrency(int id)
    {
        var currency = _context.Currencies.FirstOrDefault(c => c.Id == id);

        if (currency == null)
        {
            return false;
        }

        _context.Currencies.Remove(currency);
        _context.SaveChanges();
        return true;
    }

    public Currency? GetCurrencyById(int id)
    {
        return _context.Currencies.FirstOrDefault(c => c.Id == id);
    }

}