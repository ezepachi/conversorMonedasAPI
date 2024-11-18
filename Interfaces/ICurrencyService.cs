using System.Collections.Generic;
using conversorMonedas.Entities;

namespace conversorMonedas.Services.Interfaces
{
    public interface ICurrencyService
    {
        List<Currency> GetAllCurrencies();
        bool AddCurrency(Currency currency);
        bool UpdateCurrency(int id, Currency updatedCurrency);  // Firma del método UpdateCurrency
        bool DeleteCurrency(int id);  // Firma del método DeleteCurrency

        Currency GetCurrencyById(int id);
    }

}