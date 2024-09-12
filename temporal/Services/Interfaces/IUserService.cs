using conversorDeMonedas.Entities;
using conversorDeMonedas.Models;
using conversorDeMonedas.Entities;
using conversorDeMonedas.Models.Dtos;
using ConversorDeMonedasBack.Data.Models.Enum;

namespace conversorMonedas.Services.Interfaces
{
    public interface IUserService
    {
        User? GetById(int userId);
        User? ValidateUser(AuthenticationRequestBody authRequestBody);
        List<User> GetAll();
        bool CheckIfUserExists(int userId);
        void CreateUser(CreateAndUpdateUserDto dto);
        void UpdateUser(CreateAndUpdateUserDto dto, int userId);
        void DeleteUser(int userId);
        void UpdateUserPlan(int userId, UserPlan newPlan);
    }
}