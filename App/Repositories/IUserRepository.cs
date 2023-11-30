using App.Models;

namespace App.Repositories
{
    public interface IUserRepository
    {
        UserModel Create(UserModel user);
        List<UserModel> GetAll();
        UserModel GetForId(int id);
        UserModel Update(UserModel user);

        bool Delete(int id);
    }
}
