/*
using conversorDeMonedas.Entities;
using conversorDeMonedas.Models.Dtos;
using ConversorDeMonedasBack.Data.Models.Enum;
using conversorMonedas.Data;
using conversorMonedas.Entities;
using conversorMonedas.Services.Interfaces;
using CurrencyConverter.Data.Models.Dtos;

namespace AgendaApi.Services.Implementations
{
    public class UserService : IUserService
    {
        private ConversorContext _context;
        public UserService(ConversorContext context)
        {
            _context = context;
        }
        public User? GetById(int userId)
        {
            return _context.Users.SingleOrDefault(u => u.Id == userId);
        }

        public User? ValidateUser(AuthenticationRequestBody authRequestBody)
        {
            return _context.Users.FirstOrDefault(p => p.Email == authRequestBody.Email && p.Password == authRequestBody.Password);
        }

        public List<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public void CreateUser(CreateAndUpdateUserDto dto)
        {
            User newUser = new User()
            {
                Email = dto.Email,
                Password = dto.Password,
                Username = dto.UserName,
                Conversions = 10,
                Currencies = new List<Currency>()
            };
            _context.Users.Add(newUser);
            _context.SaveChanges();
        }

        //El update funciona de la siguiente manera:
        /*
         * Primero traemos la entidad de la base de datos.
         * Cuando traemos la entidad entity framework trackea las propiedades del objeto
         * Cuando modificamos algo el estado de la entidad pasa a "Modified"
         * Una vez hacemos _context.SaveChanges() esto va a ver que la entidad fue modificada y guarda los cambios en la base de datos.
         #1#
        public void UpdateUser(CreateAndUpdateUserDto dto, int userId)
        {
            User userToUpdate = _context.Users.First(u => u.Id == userId);
            userToUpdate.Email = dto.Email;
            userToUpdate.Password = dto.Password;
            _context.SaveChanges();
        }

        public void DeleteUser(int id)
        {
            _context.Users.Remove(_context.Users.Single(u => u.Id == id));
            _context.SaveChanges();
        }


        public bool CheckIfUserExists(int userId)
        {
            User? user = _context.Users.FirstOrDefault(user => user.Id == userId);
            return user != null;
        }

        public void UpdateUserPlan(int userId, UserPlan newPlan)
        {
            // Obtener usuario existente
            var userToUpdate = _context.Users.SingleOrDefault(u => u.Id == userId);

            // Verificar si se encontró el usuario
            if (userToUpdate == null)
            {
                throw new Exception("Usuario no encontrado"); // Manejar error si no se encuentra el usuario
            }

            // Actualizar plan de usuario
            userToUpdate.Plan = newPlan; // O TypeSubscription dependiendo de tu diseño

            // Guardar cambios en la base de datos
            _context.SaveChanges();
        }


    }
}
*/

    