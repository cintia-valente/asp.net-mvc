using App.Models;

namespace App.Repositories
{
    public interface IUserRepository
    {
        UserModel Create(UserModel user);
        UserModel GetForLogin(string login);

        UserModel GetForEmailAndLogin(string email, string login);
        List<UserModel> GetAll();
        UserModel GetForId(int id);
        UserModel Update(UserModel user);

        UserModel UpdatePassword(UpdatePasswordModel updatePasswordModel);
        bool Delete(int id);
    }
}
