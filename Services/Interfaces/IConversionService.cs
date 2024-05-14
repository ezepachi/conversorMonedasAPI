using conversorMonedas.Entities;
using conversorMonedas.Models.Dtos;

namespace conversorMonedas.Services.Interfaces
{

    namespace conversorMonedas.Services.Interfaces
    {
        public interface IConversionService
        {
            List<Conversion> GetConversions(int userId);
            void ConvertCurrency(CreateConversionDto dto);
            int ConversionCount(int userId);

        }
    }

}

