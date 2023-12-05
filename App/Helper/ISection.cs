using App.Models;

namespace App.Helper
{
    public interface ISection
    {
        void CreateUserSection(UserModel user);
        void RemoveUserSectionn();
        UserModel GetUserSection();

    }
}
