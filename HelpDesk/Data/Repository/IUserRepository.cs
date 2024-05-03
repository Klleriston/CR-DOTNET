namespace src.Data
{
    public interface IUserRepository
    {
        User Create(User user);
        User GetUserByEmail(string email);
        User GetUserById(int id);
        ICollection<User> GetAllUsers();
        void UpdateUser(User user);
        void DeleteUser(int id);
    }
}