using eshop.Entities;

namespace eshop.Application
{
    public class UserService : IUserService
    {
        private List<User> users = new List<User>()
        {
            new(){ UserName="turkayurkmez", Password="123", Role="admin", Email="info@test.com" },
            new(){ UserName="berkayciliz", Password="123", Role="editor", Email="info@test.com" },
            new(){ UserName="halit", Password="123", Role="client", Email="info@test.com" },

        };
        public User ValidateUser(string userName, string password)
        {
            return users.FirstOrDefault(u => u.UserName == userName && u.Password == password);
        }
    }
}
