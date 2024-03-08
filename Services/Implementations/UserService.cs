using conversorDeMonedas.Entities;
using conversorDeMonedas.Models.Dtos;
using conversorMonedas.Data;
using conversorMonedas.Entities;
using conversorMonedas.Services.Interfaces;

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
            return _context.Users.Include(u => u.Contacts).SingleOrDefault(u => u.Id == userId);
        }

        public User? ValidateUser(AuthenticationRequestBody authRequestBody)
        {
            return _context.Users.FirstOrDefault(p => p.UserName == authRequestBody.Email && p.Password == authRequestBody.Password);
        }

        public List<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public void Create(CreateAndUpdateUserDto dto)
        {
            User newUser = new User()
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Password = dto.Password,
                UserName = dto.UserName,
                TypeSubscription = new List<Subscriptions>() // Esto debería ser un enum, no una lista.
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
         */
        public void Update(CreateAndUpdateUserDto dto, int userId)
        {
            User userToUpdate = _context.Users.First(u => u.Id == userId);
            userToUpdate.FirstName = dto.FirstName;
            //userToUpdate.UserName = dto.NombreDeUsuario; //Esto no deberíamos actualizarlo, lo mejor es crear un dto para actualización que no contenga este campo.
            userToUpdate.LastName = dto.LastName;
            userToUpdate.Password = dto.Password;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            _context.Users.Remove(_context.Users.Single(u => u.Id == id));
            _context.SaveChanges();
        }


        public bool CheckIfUserExists(int userId)
        {
            User? user = _context.Users.FirstOrDefault(user => user.Id == userId);
            return user != null;
        }

        public void Archive(int id)
        {
            throw new NotImplementedException();
        }
    }
}
