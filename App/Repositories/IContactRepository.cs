using App.Models;

namespace App.Repositories
{
    public interface IContactRepository
    {
        ContactModel Create(ContactModel contact);
        List<ContactModel> GetAll();
        ContactModel GetForId(int id);
        ContactModel Update(ContactModel contact);

        bool Delete(int id);
    }
}
