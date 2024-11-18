using conversorMonedas.Entities;
using conversorMonedas.Models.Dtos;

namespace conversorMonedas.Interfaces
{
    public interface IUserService
    {
        IEnumerable<User> GetAllUsers();
        User GetUserById(int id);
        void CreateUser(CreateAndUpdateUserDto userDto); // Cambiado a `void` para coincidir con la implementación
        void UpdateUser(CreateAndUpdateUserDto userDto, int userId); // Agregado el `userId` como parámetro
        void DeleteUser(int id); // Cambiado a `void`
        User? ValidateUser(AuthenticationRequestBodyDto authRequestBody); // Método para validar usuario
        bool CheckIfUserExists(int userId); // Método para verificar si existe un usuario
        void UpdateUserSubscription(int userId, int subscriptionId); // Método para actualizar la suscripción
    }
}