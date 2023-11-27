using App.Models;

namespace App.Repositories
{
    public interface IContactRepository
    {
        ContactModel Create(ContactModel contact);
        List<ContactModel> GetAll();
    }
}
