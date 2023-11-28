using App.Data;
using App.Models;
using Microsoft.AspNetCore.Mvc;

namespace App.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly DatabaseContext _databaseContext;
        public ContactRepository(DatabaseContext databaseContext)
        {
            this._databaseContext = databaseContext;
        }
        public List<ContactModel> GetAll()
        {
            return _databaseContext.Contacts.ToList();
        }
        public ContactModel Create(ContactModel contact)
        {
            _databaseContext.Contacts.Add(contact);
            _databaseContext.SaveChanges();

            return contact; 
        }

        public ContactModel GetForId(int id)
        {
            return _databaseContext.Contacts.FirstOrDefault(x => x.Id == id);
        }

        public ContactModel Update(ContactModel contact)
        {
            ContactModel contactModel = GetForId(contact.Id);

            if (contactModel == null) throw new System.Exception("Erro ao atualizar!");

            contactModel.Name = contact.Name;
            contactModel.Email = contact.Email;
            contactModel.PhoneNumber = contact.PhoneNumber;

            _databaseContext.Contacts.Update(contactModel);
            _databaseContext.SaveChanges();

            return contactModel;
        }

        public bool Delete(int id)
        {
            ContactModel contactModel = GetForId(id);

            if (contactModel == null) throw new System.Exception("Erro ao apagar!");

            _databaseContext.Contacts.Remove(contactModel);
            _databaseContext.SaveChanges();

            return true;
        }
    }
}
