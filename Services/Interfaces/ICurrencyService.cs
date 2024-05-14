using conversorDeMonedas.Entities;
using conversorDeMonedas.Models.Dtos;
using conversorMonedas.Entities;

namespace conversorMonedas.Services.Interfaces
{
    public interface ICurrencyService
    {
        bool CheckICurrencyExists(int userId);
        void CreateCurrency( );
        void DeleteCurrency(int id);
        void UpdateCurrency(CreateAndUpdateUserDto dto, int userId);

        List<Currency> GetAllCurrency();
        Currency? GetByIdCurrency(int userId);
        Currency? GetByNameCurrency(int userId);

        void AddFavoriteCurrency(int userId, int currencyId);
        void DeleteFavoriteCurrency(int userId, int currencyId);
    }
}