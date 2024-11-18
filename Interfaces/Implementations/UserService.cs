using conversorMonedas.Data;
using conversorMonedas.Entities;
using conversorMonedas.Models.Dtos;
using conversorMonedas.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace conversorMonedas.Interfaces.Implementations
{
    public class UserService : IUserService
    {
        private readonly ConversorContext _context;

        public UserService(ConversorContext context)
        {
            _context = context;
        }

        // Validar credenciales de usuario
        public User? ValidateUser(AuthenticationRequestBodyDto authRequestBody)
        {
            return _context.Users.FirstOrDefault(p =>
                p.Email == authRequestBody.Email &&
                p.Password == authRequestBody.Password);
        }

        // Obtener todos los usuarios
        public IEnumerable<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        // Obtener un usuario por su ID
        public User GetUserById(int userId)
        {
            return _context.Users
                .Include(u => u.Subscription)
                .SingleOrDefault(u => u.Id == userId);
        }

        // Crear un nuevo usuario
        public void CreateUser(CreateAndUpdateUserDto dto)
        {
            var newUser = new User
            {
                Email = dto.Email,
                Firstname = dto.FirstName,
                Lastname = dto.LastName,
                Password = dto.Password, // Texto plano
                Username = dto.Username,
                Role = UserRoleEnum.User,
                SubscriptionId = dto.SubscriptionId // Enlace con la suscripción

            };

            _context.Users.Add(newUser);
            _context.SaveChanges();
        }

        // Actualizar datos de un usuario existente
        public void UpdateUser(CreateAndUpdateUserDto dto, int userId)
        {
            var userToUpdate = _context.Users.FirstOrDefault(u => u.Id == userId);

            if (userToUpdate == null)
            {
                throw new ArgumentException("Usuario no encontrado.");
            }

            userToUpdate.Firstname = dto.FirstName;
            userToUpdate.Lastname = dto.LastName;
            userToUpdate.Username = dto.Username;

            // Si el SubscriptionId es válido, buscar la suscripción correspondiente
            if (dto.SubscriptionId.HasValue)
            {
                var subscription = _context.Subscriptions.FirstOrDefault(s => s.Id == dto.SubscriptionId.Value);
                if (subscription == null)
                {
                    throw new ArgumentException("Subscripción no encontrada.");
                }

                userToUpdate.SubscriptionId = dto.SubscriptionId;
            }
            else
            {
                userToUpdate.Subscription = null; // Eliminar la suscripción si no hay SubscriptionId
            }

            _context.SaveChanges();
        }

        // Eliminar un usuario por ID
        public void DeleteUser(int userId)
        {
            var userToDelete = _context.Users.SingleOrDefault(u => u.Id == userId);
            if (userToDelete == null)
            {
                throw new ArgumentException("Usuario no encontrado.");
            }

            _context.Users.Remove(userToDelete);
            _context.SaveChanges();
        }

        // Verificar si un usuario existe
        public bool CheckIfUserExists(int userId)
        {
            return _context.Users.Any(user => user.Id == userId);
        }

        // Actualizar la suscripción de un usuario
        public void UpdateUserSubscription(int userId, int subscriptionId)
        {
            // Buscar el usuario en la base de datos
            var userToUpdate = _context.Users.Include(u => u.Subscription).FirstOrDefault(u => u.Id == userId);

            if (userToUpdate == null)
            {
                throw new ArgumentException("Usuario no encontrado.");
            }

            // Buscar la suscripción en la base de datos
            var subscription = _context.Subscriptions.FirstOrDefault(s => s.Id == subscriptionId);

            if (subscription == null)
            {
                throw new ArgumentException("Subscripción no encontrada.");
            }

            // Actualizar la suscripción del usuario
            userToUpdate.Subscription = subscription;

            // Guardar los cambios en la base de datos
            _context.SaveChanges();
        }
    }
}