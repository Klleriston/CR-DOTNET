using Microsoft.EntityFrameworkCore;

namespace src.Data
{
    public class UserService : IUserRepository
    {
        private readonly CrDB _crDB;

        public UserService(CrDB crdb)
        {
            _crDB = crdb;
        }

        public ICollection<User> GetAllUsers()
        {
            var nRegisters = 10;
            var nPages = 1;
            return _crDB.Users.AsNoTracking().Skip(nRegisters * nPages - 1).Take(nRegisters).ToList();
        }

        public User Create(User user)
        {
            _crDB.Users.Add(user);
            _crDB.SaveChanges();
            return user;
        }

        public User GetUserByEmail(string email)
        {
            return _crDB.Users.FirstOrDefault(u => u.Email == email);
        }

        public User GetUserById(int id)
        {
            return _crDB.Users.FirstOrDefault(u => u.Id == id);
        }

        public void UpdateUser(User user)
        {
            _crDB.Entry(user).State = EntityState.Modified;
            _crDB.SaveChanges();
        }

        public void DeleteUser(int id)
        {
            var user = _crDB.Users.Find(id);
            if (user != null)
            {
                _crDB.Remove(user);
                _crDB.SaveChanges();
            }
        }
    }
}